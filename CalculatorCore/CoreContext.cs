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
    /// 
    /// </summary>
    internal class CoreContext
    {
        public List<ExpressionTreeNode> NodeList { get; set; } = [];
        public List<ExpressionTreeNode> OperatorList { get; set; } = [];
        public int NetParenthesesCount { get; set; } = 0;
        public EqualTreeNode? EqualNode { get; set; } = null;
        
        public IState State { get; set; } = Maps.StateMap[StateType.InitialState];

        public string Input { get; set; } = Constants.ZERO;
        public decimal InputDecimal { get => StringHandling.StringtoDecimal(Input); }
        public string Output { get; set; } = string.Empty;

        public string Prefix()
        {
            PrefixVisitor visitor = new();
            if (NodeList.Count == 0)
            {
                return string.Empty;
            }
            NodeList[^1].AryNodeAccept(visitor);
            return visitor.Prefix.ToString();
        }

        public string Infix()
        {
           InfixVisitor visitor = new();
            if (NodeList.Count == 0)
            {
                return string.Empty;
            }
            NodeList[^1].AryNodeAccept(visitor);
            return visitor.Infix.ToString();
        }

        public string Postfix()
        {
            PostfixVisitor visitor = new();
            if (NodeList.Count == 0)
            {
                return string.Empty;
            }
            NodeList[^1].AryNodeAccept(visitor);
            return visitor.Postfix.ToString();
        }



        public CoreContext() { }

        public void Clear()
        {
            NodeList.Clear();
            OperatorList.Clear();
            State = Maps.StateMap[StateType.InitialState];
            Input = Constants.ZERO;
            Output = string.Empty;
            NetParenthesesCount = 0;
            EqualNode = null;
        }

        public void EqualClear()
        {
            ExpressionTreeNode equalTreeNode = TrimTreeHeight(NodeList[^1], 2)!;
            Clear();
            EqualNode = (EqualTreeNode)equalTreeNode!;
        }

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

        public void NumberNodePush() => NodeList.Add(new NumberTreeNode(string.Empty, Input, InputDecimal));

        public void MergeBinary()
        {
            ExpressionTreeNode op = OperatorList[OperatorList.Count - 1];
            OperatorList.RemoveAt(OperatorList.Count - 1);

            ExpressionTreeNode right = NodeList[^1];
            NodeList.RemoveAt(NodeList.Count - 1);
            ExpressionTreeNode left = NodeList[^1];
            NodeList.RemoveAt(NodeList.Count - 1);

            decimal result = MathHandling.Calculate(left.Value, char.Parse(op.Text), right.Value);
            OperatorTreeNode node = new(string.Empty, op.Text, result, left, right);
            NodeList.Add(node);
        }

        public void AddParenthesesPair()
        {
            OperatorList.RemoveAt(OperatorList.Count - 1);
            string text = $"{Constants.LEFT_PARENTHESIS}{Constants.RIGHT_PARENTHESIS}";
            var childNode = NodeList[^1];
            NodeList[^1] = new ParenthesesTreeNode(string.Empty, text, childNode.Value, childNode);
            NetParenthesesCount--;
        }
        
        public void HandleRightParenthesis()
        {
            while (OperatorList.Count > 0 && OperatorList[^1].Text != Constants.LEFT_PARENTHESIS.ToString())
            {
                MergeBinary();
            }
            AddParenthesesPair();
        }

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

        public void OperatorListAdd(char op)
        {
            OperatorList.Add(new BinaryExpressionTreeNode(string.Empty, op.ToString(), 0, null, null));
            EqualNode = null;
        }

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