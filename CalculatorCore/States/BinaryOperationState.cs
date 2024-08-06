using CalculatorCore.Interfaces;
using CalculatorCore.Utils;
using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using CalculatorCore.ExpressionTreeNodes.RealTreeNodes;
namespace CalculatorCore.States
{
    internal class BinaryOperationState : IState
    {
        public void EnterDigitDot(CoreController core, char digitDot)
        {
            core.Context.Input = StringHandling.AppendDigitDot(Constants.ZERO, digitDot);
            core.TransitionTo(StateType.NumberState);
        }
        public void EnterOperator(CoreController core, char op)
        {
            bool isBinary = core.Context.NodeList[^1] is BinaryExpressionTreeNode;
            if (isBinary && core.Context.OperatorCompare(core.Context.NodeList[^1].Text[0], op) > 0)
            {
                string text = $"{Constants.LEFT_PARENTHESIS}{Constants.RIGHT_PARENTHESIS}";
                var childNode = core.Context.NodeList[^1];
                core.Context.NodeList[^1] = new ParenthesesTreeNode(string.Empty, text, childNode.Value, childNode);
            }
            core.Context.OperatorList.RemoveAt(core.Context.OperatorList.Count - 1);
            while (core.Context.OperatorList.Count > 0 && core.Context.OperatorCompare(core.Context.OperatorList[^1].Text[0], op) <= 0)
            {
                try
                {
                    core.Context.MergeBinary();
                }
                catch
                {
                    core.Context.Input = Constants.DIVISION_ERROR;
                    core.Context.Output = string.Empty;
                    core.TransitionTo(StateType.ErrorState);
                    return;
                }
            }
            core.Context.OperatorListAdd(op);
            core.Context.Input = core.Context.NodeList[^1].Value.ToString();
            core.Context.Output = core.Context.GetOutput();
            core.TransitionTo(StateType.BinaryOperationState);
        }
        public void EnterSquareRoot(CoreController core)
        {
            NumberTreeNode numberNode = new(string.Empty, core.Context.Input, core.Context.InputDecimal);
            decimal rootValue;
            try
            {
                rootValue = MathHandling.Sqrt(core.Context.InputDecimal);
            }
            catch
            {
                core.Context.Input = Constants.SQUARE_ROOT_ERROR;
                core.Context.Output = string.Empty;
                core.TransitionTo(StateType.ErrorState);
                return;
            }
            SquareRootTreeNode squareRootNode = new(string.Empty, Constants.SQUARE_ROOT.ToString(), rootValue, numberNode);
            core.Context.NodeList.Add(squareRootNode);
            core.Context.Input = rootValue.ToString();
            core.Context.Output = core.Context.GetOutput();
            core.TransitionTo(StateType.UnaryOperationState);
        }
        public void EnterEqual(CoreController core)
        {
            core.Context.NumberNodePush();
            try
            {
                core.Context.HandleEqual();
            }
            catch
            {
                core.Context.Input = Constants.DIVISION_ERROR;
                core.Context.Output = string.Empty;
                core.TransitionTo(StateType.ErrorState);
                return;
            }

            core.Context.Input = core.Context.NodeList[^1].Value.ToString();
            core.Context.Output = core.Context.GetOutput();
            core.TransitionTo(StateType.EqualState);
        }
        public void EnterBackspace(CoreController core)
        {
            // Do nothing
        }
        public void EnterClear(CoreController core)
        {
            core.Context.Clear();
            core.TransitionTo(StateType.InitialState);
        }
        public void EnterClearEntry(CoreController core)
        {
            core.Context.Input = Constants.ZERO;
            core.TransitionTo(StateType.InitialState);
        }
        public void EnterNegate(CoreController core)
        {
            NumberTreeNode numberNode = new(string.Empty, core.Context.Input, core.Context.InputDecimal);
            NegateTreeNode negateNode = new(string.Empty, Constants.MINUS.ToString(), -core.Context.InputDecimal, numberNode);
            core.Context.NodeList.Add(negateNode);
            core.Context.Input = StringHandling.AppendNegative(core.Context.Input);
            core.Context.Output = core.Context.GetOutput();
            core.TransitionTo(StateType.UnaryOperationState);
        }

        public void EnterLeftParenthesis(CoreController core)
        {
            core.Context.OperatorList.Add(new BinaryExpressionTreeNode(string.Empty, Constants.LEFT_PARENTHESIS.ToString(), 0, null, null));
            core.Context.NetParenthesesCount++;
            core.Context.Input = Constants.ZERO;
            core.Context.Output = core.Context.GetOutput();
            core.TransitionTo(StateType.InitialState);
        }

        public void EnterRightParenthesis(CoreController core)
        {
            if (core.Context.NetParenthesesCount == 0)
            {
                return;
            }
            core.Context.NumberNodePush();
            try
            {
                core.Context.HandleRightParenthesis();
            }
            catch
            {
                core.Context.Input = Constants.DIVISION_ERROR;
                core.Context.Output = string.Empty;
                core.TransitionTo(StateType.ErrorState);
                return;
            }

            core.Context.Input = core.Context.NodeList[^1].Value.ToString();
            core.Context.Output = core.Context.GetOutput();
            core.TransitionTo(StateType.UnaryOperationState);
        }
    }
}
