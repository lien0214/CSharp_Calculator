using CalculatorCore.Interfaces;
namespace CalculatorCore.Clicks
{
    public class LeftParenthesisClick : IClick
    {
        public UIContext Click(CoreControl coreController, string buttonText)
        {
            return coreController.EnterLeftParenthesis();
        }
    }
}
