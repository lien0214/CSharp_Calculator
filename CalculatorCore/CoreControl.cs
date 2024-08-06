using CalculatorCore.Interfaces;
using CalculatorCore.Utils;

namespace CalculatorCore
{
    /// <summary>
    /// Manages the core functionality of the calculator, including state transitions and input handling.
    /// </summary>
    public class CoreControl
    {
        /// <summary>
        /// Gets the current context of the calculator which includes its state.
        /// </summary>
        internal CoreContext Context { get; private set; }

        /// <summary>
        /// Gets or sets the current state of the calculator using the context's state.
        /// </summary>
        internal IState State
        {
            get => Context.State;
            private set => Context.State = value;
        }

        /// <summary>
        /// Initializes a new instance of the CoreController class.
        /// </summary>
        public CoreControl()
        {
            Context = new CoreContext();
        }

        /// <summary>
        /// Transitions the calculator to a new state based on the specified state type.
        /// </summary>
        /// <param name="stateType">The state type to transition to.</param>
        public void TransitionTo(StateType stateType) => State = Maps.StateMap[stateType];

        /// <summary>
        /// Packages the current context into a UIContext, suitable for updating the user interface.
        /// </summary>
        /// <returns>A new UIContext containing current calculator data.</returns>
        internal UIContext PackContext()
        {
            return new UIContext(
                Context.Input,
                Context.Output,
                Context.Prefix(),
                Context.Infix(),
                Context.Postfix(),
                State != Maps.StateMap[StateType.ErrorState]
            );
        }

        /// <summary>
        /// Handles the event when a digit or dot is entered.
        /// </summary>
        /// <param name="digitDot">The character representing a digit or a dot.</param>
        /// <returns>The updated UI context after processing the input.</returns>
        internal UIContext EnterDigitDot(char digitDot)
        {
            State.EnterDigitDot(this, digitDot);
            return PackContext();
        }

        /// <summary>
        /// Handles the event when an operator is entered.
        /// </summary>
        /// <param name="op">The character representing an operator.</param>
        /// <returns>The updated UI context after processing the operator.</returns>
        internal UIContext EnterOperator(char op)
        {
            State.EnterOperator(this, op);
            return PackContext();
        }

        /// <summary>
        /// Handles the event when the square root function is triggered.
        /// </summary>
        /// <returns>The updated UI context after calculating the square root.</returns>
        internal UIContext EnterSquareRoot()
        {
            State.EnterSquareRoot(this);
            return PackContext();
        }

        /// <summary>
        /// Handles the event when the equal sign is entered to compute the result.
        /// </summary>
        /// <returns>The updated UI context after performing the calculation.</returns>
        internal UIContext EnterEqual()
        {
            State.EnterEqual(this);
            return PackContext();
        }

        /// <summary>
        /// Handles the event when the backspace is used to correct input.
        /// </summary>
        /// <returns>The updated UI context after removing the last character.</returns>
        internal UIContext EnterBackspace()
        {
            State.EnterBackspace(this);
            return PackContext();
        }

        /// <summary>
        /// Handles the event when the calculator is cleared.
        /// </summary>
        /// <returns>The updated UI context after clearing all inputs and outputs.</returns>
        internal UIContext EnterClear()
        {
            State.EnterClear(this);
            return PackContext();
        }

        /// <summary>
        /// Handles the event when the current entry is cleared.
        /// </summary>
        /// <returns>The updated UI context after clearing the current entry.</returns>
        internal UIContext EnterClearEntry()
        {
            State.EnterClearEntry(this);
            return PackContext();
        }

        /// <summary>
        /// Handles the event when the negation function is triggered.
        /// </summary>
        /// <returns>The updated UI context after negating the current value.</returns>
        internal UIContext EnterNegate()
        {
            State.EnterNegate(this);
            return PackContext();
        }

        /// <summary>
        /// Handles the event when the left parenthesis is entered for grouping expressions.
        /// </summary>
        /// <returns>The updated UI context after adding a left parenthesis.</returns>
        internal UIContext EnterLeftParenthesis()
        {
            State.EnterLeftParenthesis(this);
            return PackContext();
        }

        /// <summary>
        /// Handles the event when the right parenthesis is entered for grouping expressions.
        /// </summary>
        /// <returns>The updated UI context after adding a right parenthesis.</returns>
        internal UIContext EnterRightParenthesis()
        {
            State.EnterRightParenthesis(this);
            return PackContext();
        }
    }
}
