using CalculatorCore.Interfaces;
using CalculatorCore.Utils;
namespace CalculatorCore.States
{
    internal class ErrorState : IState
    {
        public void EnterDigitDot(CoreControl core, char digit)
        {
            core.Context.Clear();
            if (digit == Constants.DOT[0])
            {
                throw new NotImplementedException();
            }
            core.Context.Input = StringHandling.AppendDigit(core.Context.Input, digit);
            core.TransitionTo(StateType.NumberState);
        }
        public void EnterOperator(CoreControl core, char op)
        {
            throw new NotImplementedException();
        }
        public void EnterSquareRoot(CoreControl core)
        {
            throw new NotImplementedException();
        }
        public void EnterEqual(CoreControl core)
        {
            core.Context.Clear();
            core.TransitionTo(StateType.InitialState);
        }
        public void EnterBackspace(CoreControl core)
        {
            core.Context.Clear();
            core.TransitionTo(StateType.InitialState);
        }
        public void EnterClear(CoreControl core)
        {
            core.Context.Clear();
            core.TransitionTo(StateType.InitialState);
        }
        public void EnterClearEntry(CoreControl core)
        {
            core.Context.Clear();
            core.TransitionTo(StateType.InitialState);
        }
        public void EnterNegate(CoreControl core)
        {
            throw new NotImplementedException();
        }

        public void EnterLeftParenthesis(CoreControl core)
        {
            throw new NotImplementedException();
        }

        public void EnterRightParenthesis(CoreControl core)
        {
            throw new NotImplementedException();
        }
    }
}
