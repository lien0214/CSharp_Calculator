using CalculatorCore.Interfaces;

namespace CalculatorCore.Clicks
{
    /// <summary>
    /// Implementation of the IClick interface for handling digit button clicks.
    /// </summary>
    public class DigitDotClick : IClick
    {
        public UIContext Click(CoreControl coreControl, string buttonText)
        {
            return coreControl.EnterDigitDot(buttonText[0]);
        }
    }
}
