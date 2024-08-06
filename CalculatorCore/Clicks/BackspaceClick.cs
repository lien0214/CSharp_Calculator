using CalculatorCore.Interfaces;

namespace CalculatorCore.Clicks
{
    public class BackspaceClick : IClick
    {
        public UIContext Click(CoreController coreController, string buttonText)
        {
            return coreController.EnterBackspace();
        }
    }
}
