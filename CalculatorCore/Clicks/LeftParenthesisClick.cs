using CalculatorCore.Interfaces;
namespace CalculatorCore.Clicks
{
    public class LeftParenthesisClick : IClick
    {
        public UIContext Click(CoreControl coreControl, string buttonText)
        {
            return coreControl.EnterLeftParenthesis();
        }
    }
}
