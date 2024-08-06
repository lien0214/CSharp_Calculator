using Calculator.Utils;
using CalculatorCore.Interfaces;
namespace Calculator
{
    public partial class CalculatorUI : Form
    {
        public CalculatorUI()
        {
            InitializeComponent();
            CustomizeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {

        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IClick click = (button.Tag as IClick)!;
            string buttonText = button.Text;
            UIController.UpdateContext(click, buttonText);
            UpdateDisplay(button.Text);
        }

        private void UpdateDisplay(string buttonText)
        {
            LabelHelper.Render(OutputLabel, UIController.UIContext.Output);
            LabelHelper.Render(InputLabel, UIController.UIContext.Input);
            LabelHelper.Render(PrefixLabel, UIController.UIContext.Prefix);
            LabelHelper.Render(InfixLabel, UIController.UIContext.Infix);
            LabelHelper.Render(PostfixLabel, UIController.UIContext.Postfix);
            ButtonHelper.Render(Buttons, UIController.UIContext.Enables, buttonText);
        }
    }
}
