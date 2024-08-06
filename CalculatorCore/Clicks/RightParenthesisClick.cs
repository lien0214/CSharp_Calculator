using CalculatorCore.Interfaces;
namespace CalculatorCore.Clicks
{
    public class RightParenthesisClick : IClick
    {
        public UIContext Click(CoreControl coreControl, string buttonText)
        {
            return coreControl.EnterRightParenthesis();
        }
    }
}
