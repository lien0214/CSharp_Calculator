using CalculatorCore.Interfaces;

namespace CalculatorCore.Clicks
{
    /// <summary>
    /// Implementation of the IClick interface for handling clear button clicks.
    /// </summary>
    public class ClearClick : IClick
    {
        public UIContext Click(CoreControl coreController, string buttonText)
        {
            return coreController.EnterClear();
        }
    }
}
