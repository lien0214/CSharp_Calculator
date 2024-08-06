using CalculatorCore.Interfaces;
namespace CalculatorCore.Clicks
{
    public class RightParenthesisClick : IClick
    {
        public UIContext Click(CoreController coreController, string buttonText)
        {
            return coreController.EnterRightParenthesis();
        }
    }
}
