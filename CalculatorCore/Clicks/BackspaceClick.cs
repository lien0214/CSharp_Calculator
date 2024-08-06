using CalculatorCore.Interfaces;

namespace CalculatorCore.Clicks
{
    public class BackspaceClick : IClick
    {
        public UIContext Click(CoreControl coreController, string buttonText)
        {
            return coreController.EnterBackspace();
        }
    }
}
