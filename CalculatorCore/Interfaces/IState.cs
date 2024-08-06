namespace CalculatorCore.Interfaces
{
    internal interface IState
    {
        /// <summary>
        /// Handles the input of a digit.
        /// </summary>
        /// <param name="coreController">The coreController of the calculator.</param>
        /// <param name="digitDot">The digit character to be entered.</param>
        public void EnterDigitDot(CoreControl coreController, char digitDot);

        /// <summary>
        /// Handles the input of an operator.
        /// </summary>
        /// <param name="coreController">The coreController of the calculator.</param>
        /// <param name="op">The operator character to be entered.</param>
        public void EnterOperator(CoreControl coreController, char op);

        /// <summary>
        /// Handles the input of the square root operator.
        /// </summary>
        /// <param name="coreController">The coreController of the calculator.</param>
        public void EnterSquareRoot(CoreControl coreController);

        /// <summary>
        /// Handles the input of the equal sign.
        /// </summary>
        /// <param name="coreController">The coreController of the calculator.</param>
        public void EnterEqual(CoreControl coreController);

        /// <summary>
        /// Handles the input of the backspace.
        /// </summary>
        /// <param name="coreController">The coreController of the calculator.</param>
        public void EnterBackspace(CoreControl coreController);

        /// <summary>
        /// Handles the input of the clear command.
        /// </summary>
        /// <param name="coreController">The coreController of the calculator.</param>
        public void EnterClear(CoreControl coreController);

        /// <summary>
        /// Handles the input of the clear entry command.
        /// </summary>
        /// <param name="coreController">The coreController of the calculator.</param>
        public void EnterClearEntry(CoreControl coreController);

        /// <summary>
        /// Handles the input of the negate command.
        /// </summary>
        /// <param name="coreController">The coreController of the calculator.</param>
        public void EnterNegate(CoreControl coreController);

        public void EnterLeftParenthesis(CoreControl coreController);
        public void EnterRightParenthesis(CoreControl coreController);
    }
}
