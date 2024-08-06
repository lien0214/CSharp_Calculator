using CalculatorCore.Interfaces;
using CalculatorCore.Utils;
namespace CalculatorCore.States
{
    internal class ErrorState : IState
    {
        public void EnterDigitDot(CoreController core, char digit)
        {
            core.Context.Clear();
            if (digit == Constants.DOT[0])
            {
                throw new NotImplementedException();
            }
            core.Context.Input = StringHandling.AppendDigit(core.Context.Input, digit);
            core.TransitionTo(StateType.NumberState);
        }
        public void EnterOperator(CoreController core, char op)
        {
            throw new NotImplementedException();
        }
        public void EnterSquareRoot(CoreController core)
        {
            throw new NotImplementedException();
        }
        public void EnterEqual(CoreController core)
        {
            core.Context.Clear();
            core.TransitionTo(StateType.InitialState);
        }
        public void EnterBackspace(CoreController core)
        {
            core.Context.Clear();
            core.TransitionTo(StateType.InitialState);
        }
        public void EnterClear(CoreController core)
        {
            core.Context.Clear();
            core.TransitionTo(StateType.InitialState);
        }
        public void EnterClearEntry(CoreController core)
        {
            core.Context.Clear();
            core.TransitionTo(StateType.InitialState);
        }
        public void EnterNegate(CoreController core)
        {
            throw new NotImplementedException();
        }

        public void EnterLeftParenthesis(CoreController core)
        {
            throw new NotImplementedException();
        }

        public void EnterRightParenthesis(CoreController core)
        {
            throw new NotImplementedException();
        }
    }
}
