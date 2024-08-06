using Calculator.Utils;
using CalculatorCore.Utils;
using CalculatorCore.Clicks;
namespace Calculator
{
    partial class CalculatorUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // CalculatorForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 550);
            Name = "Calculator";
            Text = "Calculator";
            Load += FormLoad;
            ResumeLayout(false);
        }

        
        // Define Controller
        private UIControl UIController = new UIControl();
        // Define the components of the form
        private Label OutputLabel;
        private Label InputLabel;
        private Label PrefixLabel;
        private Label InfixLabel;
        private Label PostfixLabel;
        private Dictionary<string, Button> Buttons;
        private void CustomizeComponent()
        {
            OutputLabel = Utils.LabelHelper.Create(string.Empty, 12, Color.Gray, new Point(0, 0));
            InputLabel = Utils.LabelHelper.Create(Constants.ZERO, 16, Color.Black, new Point(0, 50));
            PrefixLabel = Utils.LabelHelper.Create(string.Empty, 12, Color.Black, new Point(0, 400));
            InfixLabel = Utils.LabelHelper.Create(string.Empty, 12, Color.Black, new Point(0, 450));
            PostfixLabel = Utils.LabelHelper.Create(string.Empty, 12, Color.Black, new Point(0, 500));
            Buttons = new Dictionary<string, Button>();

            // Add the buttons and labels to the form
            Buttons["="] = ButtonHelper.Create("=", new Point(300, 350), new EqualClick());
            Buttons["±"] = ButtonHelper.Create("±", new Point(0, 350), new NegateClick());
            Buttons["C"] = ButtonHelper.Create("C", new Point(0, 100), new ClearClick());
            Buttons["CE"] = ButtonHelper.Create("CE", new Point(0, 100), new ClearEntryClick());
            Buttons["←"] = ButtonHelper.Create("←", new Point(100, 100), new BackspaceClick());
            Buttons["%"] = ButtonHelper.Create("%", new Point(200, 100), new OperatorClick());
            Buttons["√"] = ButtonHelper.Create("√", new Point(0, 150), new SquareRootClick());
            Buttons["^"] = ButtonHelper.Create("^", new Point(300, 100), new OperatorClick());
            Buttons["+"] = ButtonHelper.Create("+", new Point(300, 150), new OperatorClick());
            Buttons["-"] = ButtonHelper.Create("-", new Point(300, 200), new OperatorClick());
            Buttons["×"] = ButtonHelper.Create("×", new Point(300, 250), new OperatorClick());
            Buttons["÷"] = ButtonHelper.Create("÷", new Point(300, 300), new OperatorClick());
            Buttons["1"] = ButtonHelper.Create("1", new Point(0, 300), new DigitDotClick());
            Buttons["2"] = ButtonHelper.Create("2", new Point(100, 300), new DigitDotClick());
            Buttons["3"] = ButtonHelper.Create("3", new Point(200, 300), new DigitDotClick());
            Buttons["4"] = ButtonHelper.Create("4", new Point(0, 250), new DigitDotClick());
            Buttons["5"] = ButtonHelper.Create("5", new Point(100, 250), new DigitDotClick());
            Buttons["6"] = ButtonHelper.Create("6", new Point(200, 250), new DigitDotClick());
            Buttons["7"] = ButtonHelper.Create("7", new Point(0, 200), new DigitDotClick());
            Buttons["8"] = ButtonHelper.Create("8", new Point(100, 200), new DigitDotClick());
            Buttons["9"] = ButtonHelper.Create("9", new Point(200, 200), new DigitDotClick());
            Buttons["0"] = ButtonHelper.Create("0", new Point(100, 350), new DigitDotClick());
            Buttons["."] = ButtonHelper.Create(".", new Point(200, 350), new DigitDotClick());
            Buttons["("] = ButtonHelper.Create("(", new Point(100, 150), new LeftParenthesisClick());
            Buttons[")"] = ButtonHelper.Create(")", new Point(200, 150), new RightParenthesisClick());

            foreach(var button in Buttons.Values)
            {
                Controls.Add(button);
                button.Click += ButtonClick;
            }
            Controls.Add(OutputLabel);
            Controls.Add(InputLabel);
            Controls.Add(PrefixLabel);
            Controls.Add(InfixLabel);
            Controls.Add(PostfixLabel);
        }
    }
}
