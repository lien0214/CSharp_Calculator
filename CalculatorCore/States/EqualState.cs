using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using CalculatorCore.ExpressionTreeNodes.RealTreeNodes;
using CalculatorCore.Interfaces;
using CalculatorCore.Utils;

namespace CalculatorCore.States
{
    internal class EqualState : IState
    {
        public void EnterDigitDot(CoreController core, char digitDot)
        {
            core.Context.EqualClear();
            core.Context.Input = StringHandling.AppendDigitDot(core.Context.Input, digitDot);
            core.TransitionTo(StateType.NumberState);
        }
        public void EnterOperator(CoreController core, char op)
        {
            NumberTreeNode numberNode = new(string.Empty, core.Context.Input, core.Context.InputDecimal);
            core.Context.EqualClear();
            core.Context.NodeList.Add(numberNode);
            core.Context.OperatorListAdd(op);
            core.Context.Input = core.Context.NodeList[^1].Value.ToString();
            core.Context.Output = core.Context.GetOutput();
            core.TransitionTo(StateType.BinaryOperationState);
        }
        public void EnterSquareRoot(CoreController core)
        {
            NumberTreeNode numberNode = new(string.Empty, core.Context.Input, core.Context.InputDecimal);
            decimal rootValue = MathHandling.Sqrt(core.Context.InputDecimal);
            SquareRootTreeNode squareRootNode = new(string.Empty, Constants.SQUARE_ROOT.ToString(), rootValue, numberNode);
            core.Context.EqualClear();
            core.Context.NodeList.Add(squareRootNode);
            core.Context.Input = rootValue.ToString();
            core.Context.Output = core.Context.GetOutput();
            core.TransitionTo(StateType.UnaryOperationState);
        }
        public void EnterEqual(CoreController core)
        {
            NumberTreeNode numberNode = new(string.Empty, core.Context.Input, core.Context.InputDecimal);
            core.Context.EqualClear();
            core.Context.NodeList.Add(numberNode);
            core.Context.HandleEqual();
            core.Context.Input = core.Context.NodeList[^1].Value.ToString();
            core.Context.Output = core.Context.GetOutput();
            core.TransitionTo(StateType.EqualState);
        }
        public void EnterBackspace(CoreController core)
        {
            var input = core.Context.Input;
            core.Context.EqualClear();
            core.Context.Input = input;
            core.TransitionTo(StateType.EqualState);
        }
        public void EnterClear(CoreController core)
        {
            core.Context.Clear();
        }
        public void EnterClearEntry(CoreController core)
        {
            core.Context.EqualClear();
        }
        public void EnterNegate(CoreController core)
        {
            NumberTreeNode childNode = new(string.Empty, core.Context.Input, core.Context.InputDecimal);
            decimal negateValue = -core.Context.InputDecimal;
            NegateTreeNode negateNode = new(string.Empty, Constants.SQUARE_ROOT.ToString(), negateValue, childNode);
            core.Context.EqualClear();
            core.Context.NodeList.Add(negateNode);
            core.Context.Input = core.Context.NodeList[^1].Value.ToString();
            core.Context.Output = core.Context.GetOutput();
        }

        public void EnterLeftParenthesis(CoreController core)
        {
            string input = core.Context.Input;
            core.Context.EqualClear();
            core.Context.Input = input;
            core.Context.OperatorList.Add(new UnaryExpressionTreeNode(string.Empty, Constants.LEFT_PARENTHESIS.ToString(), 0, null));
            core.Context.NetParenthesesCount++;
            core.Context.Output = core.Context.GetOutput();
            core.TransitionTo(StateType.InitialState);
        }

        public void EnterRightParenthesis(CoreController core)
        {
            string input = core.Context.Input;
            core.Context.EqualClear();
            core.Context.Input = input;
            core.Context.Output = core.Context.GetOutput();
            core.TransitionTo(StateType.InitialState);
        }
    }
}
