namespace Calculator.Utils
{
    internal static class LabelHelper
    {
        /// <summary>
        /// Creates a new label with specified text, location, and click action.
        /// </summary>
        /// <param name="text">The text to display on the label.</param>
        /// <param name="location">The location where the label will be placed.</param>
        /// <returns>A new Label object configured with the specified parameters.</returns>
        public static Label Create(string text, int fontSize, Color fontColor, Point location)
        {
            return new Label
            {
                Text = text,
                AutoSize = false,
                Size = new Size(400, 50),
                TabIndex = 0,
                TextAlign = ContentAlignment.BottomRight,
                Font = new Font("Consolas", fontSize, FontStyle.Regular),
                ForeColor = fontColor,
                Location = location
            };
        }
        /// <summary>
        /// Updates the text displayed on the label.
        /// </summary>
        /// <param name="text">The new text to display.</param>
        public static void Render(Label label, string text)
        {
            label.Text = text;
        }
    }
}
