namespace CalculatorCore.Interfaces
{
    /// <summary>
    /// Interface representing a click action in the calculator.
    /// Defines a method for handling button clicks.
    /// </summary>
    public interface IClick
    {
        /// <summary>
        /// Handles the click event for a calculator button.
        /// </summary>
        /// <param name="context">The context of the calculator.</param>
        /// <param name="buttonText">The text of the button that was clicked.</param>
        public UIContext Click(CoreController coreController, string buttonText);
    }
}
