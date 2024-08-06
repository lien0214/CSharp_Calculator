using CalculatorCore.Interfaces;

namespace CalculatorCore.Clicks
{
    public class DefaultClick : IClick
    {
        public UIContext Click(CoreControl coreControl, string buttonText)
        {
            return new UIContext();
        }
    }
}
