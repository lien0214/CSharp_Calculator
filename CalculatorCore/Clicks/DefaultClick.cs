using CalculatorCore.Interfaces;

namespace CalculatorCore.Clicks
{
    public class DefaultClick : IClick
    {
        public UIContext Click(CoreController coreController, string buttonText)
        {
            return new UIContext();
        }
    }
}
