using CalculatorCore.Abstracts;
using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using CalculatorCore.ExpressionTreeNodes.RealTreeNodes;
using CalculatorCore.Interfaces;
using CalculatorCore.Utils;
using CalculatorCore.Visitors;
using System.Text;
namespace CalculatorCore
{
    /// <summary>
    /// CoreContext is the main class that holds the state and Value of the calculator.
    /// </summary>
    internal class CoreContext
    {
        /// <summary>
        /// NodeList is a list of ExpressionTreeNode that holds the nodes of the expression tree.
        /// </summary>
        public List<ExpressionTreeNode> NodeList { get; set; }

        /// <summary>
        /// OperatorList is a list of ExpressionTreeNode that holds the operators of the expression tree.
        /// </summary>
        public List<ExpressionTreeNode> OperatorList { get; set; }

        /// <summary>
        /// NetParenthesesCount is the number of parentheses that are not closed.
        /// </summary>
        public int NetParenthesesCount { get; set; }

        /// <summary>
        /// EqualNode is the node that holds the equal sign.
        /// </summary>
        public EqualTreeNode? EqualNode { get; set; }
        
        /// <summary>
        /// State is the current state of the calculator.
        /// </summary>
        public IState State { get; set; }

        /// <summary>
        /// Input is the current input of the calculator.
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// InputDecimal is the decimal representation of the input.
        /// </summary>
        public decimal InputDecimal { get => StringHandling.StringtoDecimal(Input); }

        /// <summary>
        /// Output is the output of the calculator.
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// Preorder returns the preorder notation of the expression tree.
        /// </summary>Infix
        /// <returns>The preorder string of the Last tree in the List</returns>
        public string Preorder()
        {
            PrefixVisitor visitor = new();
            if (NodeList.Count == 0)
            {
                return string.Empty;
            }
            NodeList[^1].AryNodeAccept(visitor);
            return visitor.Preorder.ToString();
        }

        /// <summary>
        /// Inorder returns the inorder notation of the expression tree.
        /// </summary>
        /// <returns>The inorder string of the Last tree in the List</returns>
        public string Inorder()
        {
           InfixVisitor visitor = new();
            if (NodeList.Count == 0)
            {
                return string.Empty;
            }
            NodeList[^1].AryNodeAccept(visitor);
            return visitor.Inorder.ToString();
        }

        /// <summary>
        /// Postorder returns the postorder notation of the expression tree.
        /// </summary>
        /// <returns>The postorder string of the Last tree in the List</returns>
        public string Postorder()
        {
            PostfixVisitor visitor = new();
            if (NodeList.Count == 0)
            {
                return string.Empty;
            }
            NodeList[^1].AryNodeAccept(visitor);
            return visitor.Postfix.ToString();
        }

        public CoreContext()
        {
            NodeList = [];
            OperatorList = [];
            NetParenthesesCount = 0;
            EqualNode = null;
            State = Maps.StateMap[StateType.InitialState];
            Input = Constants.ZERO;
            Output = string.Empty;
        }

        /// <summary>
        /// Clear clears the state of the calculator.
        /// </summary>
        public void Clear()
        {
            NodeList.Clear();
            OperatorList.Clear();
            NetParenthesesCount = 0;
            EqualNode = null;
            State = Maps.StateMap[StateType.InitialState];
            Input = Constants.ZERO;
            Output = string.Empty;
        }

        /// <summary>
        /// Stores EqualTreeNode, clears the state of the calculator and resets the state to InitialState.
        /// </summary>
        public void EqualClear()
        {
            ExpressionTreeNode equalTreeNode = TrimTreeHeight(NodeList[^1], 2)!;
            Clear();
            EqualNode = (EqualTreeNode)equalTreeNode!;
        }

        /// <summary>
        /// Compare the precedence of two operators.
        /// </summary>
        /// <param name="op1">Operand on left-hand side</param>
        /// <param name="op2">Operand on right-hand side</param>
        /// <returns>return the precedence subtraction of two operators.</returns>
        public int OperatorCompare(char op1, char op2)
        {
            Dictionary<char, int> OperatorPrecedence = new()
            {
                { Constants.LEFT_PARENTHESIS, 0 },
                { Constants.PLUS, 1 },
                { Constants.MINUS, 1 },
                { Constants.MULTIPLY, 2 },
                { Constants.DIVIDE, 2 },
                { Constants.MOD, 2},
                { Constants.POWER, 3 },
            };
            return OperatorPrecedence[op2] - OperatorPrecedence[op1];
        }

        /// <summary>
        /// NumberNodePush creates a NumberTreeNode and adds it to the NodeList.
        /// </summary>
        public void NumberNodePush() => NodeList.Add(new NumberTreeNode(string.Empty, Input, InputDecimal));

        /// <summary>
        /// MergeBinary merges two nodes with one binary operator node.
        /// </summary>
        public void MergeBinary()
        {
            ExpressionTreeNode op = OperatorList[^1];
            OperatorList.RemoveAt(OperatorList.Count - 1);

            ExpressionTreeNode right = NodeList[^1];
            NodeList.RemoveAt(NodeList.Count - 1);
            ExpressionTreeNode left = NodeList[^1];
            NodeList.RemoveAt(NodeList.Count - 1);

            decimal result = MathHandling.Calculate(left.Value, char.Parse(op.Text), right.Value);
            OperatorTreeNode node = new(string.Empty, op.Text, result, left, right);
            NodeList.Add(node);
        }

        /// <summary>
        /// Removes the last operator from the OperatorList and adds a new ParenthesesTreeNode to the NodeList.
        /// The new node is created with the left and right parentheses and the last node from the NodeList as its child.
        /// </summary>
        public void AddParenthesesPair()
        {
            OperatorList.RemoveAt(OperatorList.Count - 1);
            string text = $"{Constants.LEFT_PARENTHESIS}{Constants.RIGHT_PARENTHESIS}";
            var childNode = NodeList[^1];
            NodeList[^1] = new ParenthesesTreeNode(string.Empty, text, childNode.Value, childNode);
            NetParenthesesCount--;
        }

        /// <summary>
        /// Handles the insertion of a right parenthesis by merging binary nodes until a left parenthesis is found
        /// and then calls AddParenthesesPair to properly encapsulate the expression within parentheses.
        /// </summary>
        public void HandleRightParenthesis()
        {
            while (OperatorList.Count > 0 && OperatorList[^1].Text != Constants.LEFT_PARENTHESIS.ToString())
            {
                MergeBinary();
            }
            AddParenthesesPair();
        }

        /// <summary>
        /// Handles the equal operation by either finalizing the existing EqualNode or merging all operators
        /// and then creating a new EqualTreeNode with the result.
        /// </summary>
        public void HandleEqual()
        {
            if (EqualNode != null)
            {
                if (EqualNode.Child is null)
                {
                    return;
                }
                if (EqualNode.Child is OperatorTreeNode operatorNode)
                {
                    operatorNode.Left = NodeList[^1];
                    operatorNode.Value = MathHandling.Calculate(operatorNode.Left!.Value, operatorNode.Text[0], operatorNode.Right!.Value);
                    EqualNode.TextFormula = string.Empty;
                    EqualNode.Value = operatorNode.Value;
                    NodeList[^1] = EqualNode;
                    return;
                }
            }
            while (OperatorList.Count > 0)
            {
                if (OperatorList[^1].Text == "(")
                {
                    AddParenthesesPair();
                }
                else
                {
                    MergeBinary();
                }
            }
            var equalChild = NodeList[^1];
            string equalText = Constants.EQUAL.ToString();
            NodeList[^1] = new EqualTreeNode(string.Empty, equalText, equalChild.Value, equalChild);
        }

        /// <summary>
        /// Adds a new BinaryExpressionTreeNode to the OperatorList with the specified operator character.
        /// Sets the EqualNode to null.
        /// </summary>
        public void OperatorListAdd(char op)
        {
            OperatorList.Add(new BinaryExpressionTreeNode(string.Empty, op.ToString(), 0, null, null));
            EqualNode = null;
        }

        /// <summary>
        /// Trims the height of the expression tree to the specified target height.
        /// </summary>
        /// <param name="root">The root node of the tree to trim.</param>
        /// <param name="targetHeight">The target height to trim the tree to.</param>
        /// <returns>The trimmed tree node.</returns>
        public static ExpressionTreeNode? TrimTreeHeight(ExpressionTreeNode? root, int targetHeight)
        {
            if (root == null || targetHeight < 0)
            {
                return null;
            }
            if (targetHeight == 0)
            {
                return new NumberTreeNode(string.Empty, root.Value.ToString(), root.Value);
            }
            if (root is BinaryExpressionTreeNode binary)
            {
                binary.TextFormula = string.Empty;
                binary.Left = TrimTreeHeight(binary.Left, targetHeight - 1);
                binary.Right = TrimTreeHeight(binary.Right, targetHeight - 1);
                return binary;
            }
            else if (root is UnaryExpressionTreeNode unary)
            {
                unary.TextFormula = string.Empty;
                unary.Child = TrimTreeHeight(unary.Child, targetHeight - 1);
                return unary;
            }
            else if (root is NullaryExpressionTreeNode nullary)
            {
                return nullary;
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates the output string of the expression tree by traversing the NodeList and OperatorList.
        /// </summary>
        /// <returns>The output string representing the expression tree.</returns>
        public string GetOutput()
        {
            int nodeIndex = 0;
            int operatorIndex = 0;
            StringBuilder returnBuilder = new();
            TreeOutputVisitor visitor = new();
            // Both NodeList and OperatorList are sorted by index
            while (nodeIndex < NodeList.Count && operatorIndex < OperatorList.Count)
            {
                if (NodeList[nodeIndex].Index < OperatorList[operatorIndex].Index)
                {
                    NodeList[nodeIndex].RealNodeAccept(visitor);
                    returnBuilder.Append(NodeList[nodeIndex++].TextFormula);
                }
                else
                {
                    returnBuilder.Append(OperatorList[operatorIndex++].Text);
                }
            }
            while (nodeIndex < NodeList.Count)
            {
                NodeList[nodeIndex].RealNodeAccept(visitor);
                returnBuilder.Append(NodeList[nodeIndex++].TextFormula);
            }
            while (operatorIndex < OperatorList.Count)
            {
                returnBuilder.Append(OperatorList[operatorIndex++].Text);
            }
            return returnBuilder.ToString();
        }
    }
}