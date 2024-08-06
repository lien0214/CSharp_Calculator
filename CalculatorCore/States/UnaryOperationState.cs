using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using CalculatorCore.ExpressionTreeNodes.RealTreeNodes;
using CalculatorCore.Interfaces;
using CalculatorCore.Utils;
namespace CalculatorCore.States
{
    internal class UnaryOperationState : IState
    {
        public void EnterDigitDot(CoreControl core, char digitDot)
        {
            core.Context.NodeList.RemoveAt(core.Context.NodeList.Count - 1);
            core.Context.Input = StringHandling.AppendDigitDot(Constants.ZERO, digitDot);
            core.TransitionTo(StateType.NumberState);
        }
        public void EnterOperator(CoreControl core, char op)
        {
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
        public void EnterSquareRoot(CoreControl core)
        {
            UnaryExpressionTreeNode unary = (UnaryExpressionTreeNode)core.Context.NodeList[^1];
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
            core.Context.NodeList[^1] = new SquareRootTreeNode(string.Empty, Constants.SQUARE_ROOT.ToString(), rootValue, unary);
            core.Context.Input = rootValue.ToString();
            core.Context.Output = core.Context.GetOutput();
            core.TransitionTo(StateType.UnaryOperationState);
        }
        public void EnterEqual(CoreControl core)
        {
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
        public void EnterBackspace(CoreControl core)
        {
            // Do nothing
        }
        public void EnterClear(CoreControl core)
        {
            core.Context.Clear();
        }
        public void EnterClearEntry(CoreControl core)
        {
            core.Context.NodeList.RemoveAt(core.Context.NodeList.Count - 1);
            core.Context.Input = Constants.ZERO;
            core.TransitionTo(StateType.InitialState);
        }
        public void EnterNegate(CoreControl core)
        {
            UnaryExpressionTreeNode unary = (UnaryExpressionTreeNode)core.Context.NodeList[^1];
            decimal negationValue = -core.Context.InputDecimal;
            core.Context.NodeList[^1] = new NegateTreeNode(string.Empty, Constants.MINUS.ToString(), negationValue, unary);
            core.Context.Input = negationValue.ToString();
            core.Context.Output = core.Context.GetOutput();
            core.TransitionTo(StateType.UnaryOperationState);
        }

        public void EnterLeftParenthesis(CoreControl core)
        {
            while (core.Context.OperatorList.Count > 0 && core.Context.OperatorCompare(core.Context.OperatorList[^1].Text[0], Constants.MULTIPLY) <= 0)
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
            core.Context.OperatorListAdd(Constants.MULTIPLY);
            core.Context.OperatorList.Add(new BinaryExpressionTreeNode(string.Empty, Constants.LEFT_PARENTHESIS.ToString(), 0, null, null));
            core.Context.NetParenthesesCount++;
            core.Context.Output = core.Context.GetOutput();
            core.TransitionTo(StateType.InitialState);
        }

        public void EnterRightParenthesis(CoreControl core)
        {
            if (core.Context.NetParenthesesCount == 0)
            {
                return;
            }
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
