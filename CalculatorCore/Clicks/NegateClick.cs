using CalculatorCore.Interfaces;

namespace CalculatorCore.Clicks
{
    /// <summary>
    /// Implementation of the IClick interface for handling negate button clicks.
    /// </summary>
    public class NegateClick : IClick
    {
        public UIContext Click(CoreControl coreController, string buttonText)
        {
            return coreController.EnterNegate();
        }
    }
}
