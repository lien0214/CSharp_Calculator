namespace CalculatorCore
{
    public partial class CoreController
    {
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
