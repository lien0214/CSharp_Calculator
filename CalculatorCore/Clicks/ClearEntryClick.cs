﻿using CalculatorCore.Interfaces;

namespace CalculatorCore.Clicks
{
    /// <summary>
    /// Implementation of the IClick interface for handling clear entry button clicks.
    /// </summary>
    public class ClearEntryClick : IClick
    {
        public UIContext Click(CoreControl coreControl, string buttonText)
        {
            return coreControl.EnterClearEntry();
        }
    }
}
