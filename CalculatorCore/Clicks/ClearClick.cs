using CalculatorCore.Interfaces;

namespace CalculatorCore.Clicks
{
    /// <summary>
    /// Implementation of the IClick interface for handling clear button clicks.
    /// </summary>
    public class ClearClick : IClick
    {
        public UIContext Click(CoreControl coreControl, string buttonText)
        {
            return coreControl.EnterClear();
        }
    }
}
