namespace CalculatorCore.Interfaces
{
    internal interface IState
    {
        /// <summary>
        /// Handles the input of a digit.
        /// </summary>
        /// <param name="coreControl">The coreControl of the calculator.</param>
        /// <param name="digitDot">The digit character to be entered.</param>
        public void EnterDigitDot(CoreControl coreControl, char digitDot);

        /// <summary>
        /// Handles the input of an operator.
        /// </summary>
        /// <param name="coreControl">The coreControl of the calculator.</param>
        /// <param name="op">The operator character to be entered.</param>
        public void EnterOperator(CoreControl coreControl, char op);

        /// <summary>
        /// Handles the input of the square root operator.
        /// </summary>
        /// <param name="coreControl">The coreControl of the calculator.</param>
        public void EnterSquareRoot(CoreControl coreControl);

        /// <summary>
        /// Handles the input of the equal sign.
        /// </summary>
        /// <param name="coreControl">The coreControl of the calculator.</param>
        public void EnterEqual(CoreControl coreControl);

        /// <summary>
        /// Handles the input of the backspace.
        /// </summary>
        /// <param name="coreControl">The coreControl of the calculator.</param>
        public void EnterBackspace(CoreControl coreControl);

        /// <summary>
        /// Handles the input of the clear command.
        /// </summary>
        /// <param name="coreControl">The coreControl of the calculator.</param>
        public void EnterClear(CoreControl coreControl);

        /// <summary>
        /// Handles the input of the clear entry command.
        /// </summary>
        /// <param name="coreControl">The coreControl of the calculator.</param>
        public void EnterClearEntry(CoreControl coreControl);

        /// <summary>
        /// Handles the input of the negate command.
        /// </summary>
        /// <param name="coreControl">The coreControl of the calculator.</param>
        public void EnterNegate(CoreControl coreControl);

        public void EnterLeftParenthesis(CoreControl coreControl);
        public void EnterRightParenthesis(CoreControl coreControl);
    }
}
