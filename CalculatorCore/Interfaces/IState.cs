namespace CalculatorCore.Interfaces
{
    internal interface IState
    {
        /// <summary>
        /// Handles the input of a digit.
        /// </summary>
        /// <param name="coreController">The coreController of the calculator.</param>
        /// <param name="digitDot">The digit character to be entered.</param>
        public void EnterDigitDot(CoreController coreController, char digitDot);

        /// <summary>
        /// Handles the input of an operator.
        /// </summary>
        /// <param name="coreController">The coreController of the calculator.</param>
        /// <param name="op">The operator character to be entered.</param>
        public void EnterOperator(CoreController coreController, char op);

        /// <summary>
        /// Handles the input of the square root operator.
        /// </summary>
        /// <param name="coreController">The coreController of the calculator.</param>
        public void EnterSquareRoot(CoreController coreController);

        /// <summary>
        /// Handles the input of the equal sign.
        /// </summary>
        /// <param name="coreController">The coreController of the calculator.</param>
        public void EnterEqual(CoreController coreController);

        /// <summary>
        /// Handles the input of the backspace.
        /// </summary>
        /// <param name="coreController">The coreController of the calculator.</param>
        public void EnterBackspace(CoreController coreController);

        /// <summary>
        /// Handles the input of the clear command.
        /// </summary>
        /// <param name="coreController">The coreController of the calculator.</param>
        public void EnterClear(CoreController coreController);

        /// <summary>
        /// Handles the input of the clear entry command.
        /// </summary>
        /// <param name="coreController">The coreController of the calculator.</param>
        public void EnterClearEntry(CoreController coreController);

        /// <summary>
        /// Handles the input of the negate command.
        /// </summary>
        /// <param name="coreController">The coreController of the calculator.</param>
        public void EnterNegate(CoreController coreController);

        public void EnterLeftParenthesis(CoreController coreController);
        public void EnterRightParenthesis(CoreController coreController);
    }
}
