using CalculatorCore.Interfaces;

namespace CalculatorCore.Clicks
{
    /// <summary>
    /// Implementation of the IClick interface for handling equal button clicks.
    /// </summary>
    public class EqualClick : IClick
    {
        public UIContext Click(CoreController coreController, string buttonText)
        {
            return coreController.EnterEqual();
        }
    }
}
