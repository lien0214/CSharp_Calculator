using CalculatorCore.Interfaces;
namespace CalculatorCore.Clicks
{
    public class RightParenthesisClick : IClick
    {
        public UIContext Click(CoreControl coreController, string buttonText)
        {
            return coreController.EnterRightParenthesis();
        }
    }
}
