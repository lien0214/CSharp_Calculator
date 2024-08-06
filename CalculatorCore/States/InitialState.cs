using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using CalculatorCore.ExpressionTreeNodes.RealTreeNodes;
using CalculatorCore.Interfaces;
using CalculatorCore.Utils;
namespace CalculatorCore.States
{
    internal class InitialState : IState
    {
        public void EnterBackspace(CoreControl core)
        {
            // Do nothing
        }

        public void EnterClear(CoreControl core)
        {
            core.Context.Clear();
            core.TransitionTo(StateType.InitialState);
        }

        public void EnterClearEntry(CoreControl core)
        {
            core.Context.Input = Constants.ZERO;
            core.TransitionTo(StateType.InitialState);
        }

        public void EnterDigitDot(CoreControl core, char digitDot)
        {
            core.Context.Input = StringHandling.AppendDigitDot(Constants.ZERO, digitDot);
            core.TransitionTo(StateType.NumberState);
        }

        public void EnterEqual(CoreControl core)
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

        public void EnterLeftParenthesis(CoreControl core)
        {
            core.Context.OperatorList.Add(new UnaryExpressionTreeNode(string.Empty, Constants.LEFT_PARENTHESIS.ToString(), 0, null));
            core.Context.NetParenthesesCount++;
            core.Context.Output = core.Context.GetOutput();
            core.TransitionTo(StateType.InitialState);
        }

        public void EnterNegate(CoreControl core)
        {
            // Do nothing
        }

        public void EnterOperator(CoreControl core, char op)
        {
            core.Context.NumberNodePush();
            core.Context.OperatorListAdd(op);
            core.Context.Input = core.Context.NodeList[^1].Value.ToString();
            core.Context.Output = core.Context.GetOutput();
            core.TransitionTo(StateType.BinaryOperationState);
        }

        public void EnterRightParenthesis(CoreControl core)
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

        public void EnterSquareRoot(CoreControl core)
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
    }
}
