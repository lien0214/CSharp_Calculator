using CalculatorCore.Interfaces;

namespace CalculatorCore.Clicks
{
    public class DefaultClick : IClick
    {
        public UIContext Click(CoreControl coreController, string buttonText)
        {
            return new UIContext();
        }
    }
}
