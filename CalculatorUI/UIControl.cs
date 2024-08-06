using CalculatorCore;
using CalculatorCore.Interfaces;

namespace Calculator
{
    /// <summary>
    /// Manages the user interface interactions and updates the UI context based on user actions.
    /// </summary>
    internal class UIControl
    {
        /// <summary>
        /// Gets the current UI context that holds all the necessary UI data.
        /// </summary>
        public UIContext UIContext { get; private set; }

        /// <summary>
        /// A reference to the CoreControl which handles the core calculator logic.
        /// </summary>
        private readonly CoreControl CoreControl;

        /// <summary>
        /// Initializes a new instance of the UIControl class.
        /// </summary>
        public UIControl()
        {
            // Initialize a new UI context.
            UIContext = new UIContext();

            // Create an instance of CoreControl to handle calculator operations.
            CoreControl = new CoreControl();
        }

        /// <summary>
        /// Updates the UI context based on the button clicked and the type of action defined by the IClick interface.
        /// </summary>
        /// <param name="click">An implementation of the IClick interface that defines how to handle different button clicks.</param>
        /// <param name="buttonText">The text on the button that was clicked, used to determine the action to take.</param>
        public void UpdateContext(IClick click, string buttonText)
        {
            // Update the UIContext by performing the click action through the CoreControl, based on the button text.
            UIContext = click.Click(CoreControl, buttonText);
        }
    }
}
