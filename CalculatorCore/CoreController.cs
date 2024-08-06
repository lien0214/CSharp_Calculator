using CalculatorCore.Interfaces;
using CalculatorCore.Utils;
namespace CalculatorCore
{
    public class CoreController
    {
        internal CoreContext Context { get; private set; }
        internal IState State { get => Context.State; private set => Context.State = value; }

        public void TransitionTo(StateType stateType) => State = Maps.StateMap[stateType];

        public CoreController()
        {
            Context = new CoreContext();
        }

        internal UIContext PackContext()
        {
            bool isNotError = State != Maps.StateMap[StateType.ErrorState];
            return new(Context.Input, Context.Output, Context.Prefix(), Context.Infix(), Context.Postfix(), isNotError);
        }

        internal UIContext EnterDigitDot(char digitDot)
        {
            State.EnterDigitDot(this, digitDot);
            return PackContext();
        }
        internal UIContext EnterOperator(char op)
        {
            State.EnterOperator(this, op);
            return PackContext();
        }
        internal UIContext EnterSquareRoot()
        {
            State.EnterSquareRoot(this);
            return PackContext();
        }
        internal UIContext EnterEqual()
        {
            State.EnterEqual(this);
            return PackContext();
        }

        internal UIContext EnterBackspace()
        {
            State.EnterBackspace(this);
            return PackContext();
        }
        internal UIContext EnterClear()
        {
            State.EnterClear(this);
            return PackContext();
        }
        internal UIContext EnterClearEntry()
        {
            State.EnterClearEntry(this);
            return PackContext();
        }
        internal UIContext EnterNegate()
        {
            State.EnterNegate(this);
            return PackContext();
        }

        internal UIContext EnterLeftParenthesis()
        {
            State.EnterLeftParenthesis(this);
            return PackContext();
        }

        internal UIContext EnterRightParenthesis()
        {
            State.EnterRightParenthesis(this);
            return PackContext();
        }
    }
}