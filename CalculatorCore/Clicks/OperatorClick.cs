using CalculatorCore.Interfaces;

namespace CalculatorCore.Clicks
{
    /// <summary>
    /// Implementation of the IClick interface for handling operator button clicks.
    /// </summary>
    public class OperatorClick : IClick
    {
        public UIContext Click(CoreControl coreControl, string buttonText)
        {
            return coreControl.EnterOperator(buttonText[0]);
        }
    }
}
