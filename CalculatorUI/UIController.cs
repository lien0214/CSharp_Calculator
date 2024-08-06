using CalculatorCore;
using CalculatorCore.Interfaces;
namespace Calculator
{
    internal class UIController
    {
        public UIContext UIContext { get; private set; }
        private readonly CoreController CoreController;

        public UIController()
        {
            UIContext = new UIContext();
            CoreController = new CoreController();
        }

        public void UpdateContext(IClick click, string buttonText)
        {
            UIContext = click.Click(CoreController, buttonText);
        }
    }
}
