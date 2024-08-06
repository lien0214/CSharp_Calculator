using CalculatorCore.Interfaces;

namespace CalculatorCore.Clicks
{
    public class BackspaceClick : IClick
    {
        public UIContext Click(CoreControl coreControl, string buttonText)
        {
            return coreControl.EnterBackspace();
        }
    }
}
