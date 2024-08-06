using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorCore.Interfaces;

namespace CalculatorCore.Clicks
{
    public class SquareRootClick : IClick
    {
        public UIContext Click(CoreControl coreController, string buttonText)
        {
            return coreController.EnterSquareRoot();
        }
    }
}
