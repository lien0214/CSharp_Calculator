using CalculatorCore.Interfaces;

namespace CalculatorCore.Clicks
{
    /// <summary>
    /// Implementation of the IClick interface for handling operator button clicks.
    /// </summary>
    public class OperatorClick : IClick
    {
        public UIContext Click(CoreController coreController, string buttonText)
        {
            return coreController.EnterOperator(buttonText[0]);
        }
    }
}
