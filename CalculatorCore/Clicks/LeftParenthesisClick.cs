using CalculatorCore.Interfaces;
namespace CalculatorCore.Clicks
{
    public class LeftParenthesisClick : IClick
    {
        public UIContext Click(CoreController coreController, string buttonText)
        {
            return coreController.EnterLeftParenthesis();
        }
    }
}
