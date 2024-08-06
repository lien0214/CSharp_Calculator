using CalculatorCore.Interfaces;
namespace Calculator.Utils
{
    internal static class ButtonHelper
    {
        /// <summary>
        /// Creates a new button with specified text, location, and click action.
        /// </summary>
        /// <param name="text">The text to display on the button.</param>
        /// <param name="location">The location where the button will be placed.</param>
        /// <param name="action">The action to perform when the button is clicked, implementing the IClick interface.</param>
        /// <returns>A new Button object configured with the specified parameters.</returns>
        public static Button Create(string text, Point location, IClick action)
        {
            return new Button
            {
                Name = text,
                Text = text,
                Location = location,
                Font = new Font("Consolas", 10),
                Size = new Size(100, 50),
                Tag = action
            };
        }

        /// <summary>
        /// Render the button on the form.
        /// </summary>
        /// <param name="buttons">A dictionary of buttons to render.</param>
        /// <param name="enables">A dictionary of button enabled states.</param>
        /// <param name="buttonText">The text of the button to render.</param>
        public static void Render(Dictionary<string, Button> buttons, Dictionary<string, bool> enables, string buttonText)
        {
            // Set the visibility of the "C" button
            if (buttonText == "CE")
            {
                buttons["C"].Visible = true;
            }
            else if (int.TryParse(buttonText, out _))
            {
                buttons["C"].Visible = false;
            }

            // Set the enabled state of the operator buttons
            foreach (var key in enables.Keys)
            {
                buttons[key].Enabled = enables[key];
            }
        }
    }
}
