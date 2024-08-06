namespace CalculatorCore.Interfaces
{
    /// <summary>
    /// Interface representing a click action in the calculator.
    /// Defines a method for handling button clicks.
    /// </summary>
    public interface IClick
    {
        /// <summary>
        /// Method for handling button clicks.
        /// </summary>
        /// <param name="coreControl">Core manager to call</param>
        /// <param name="buttonText">Input text</param>
        /// <returns></returns>
        public UIContext Click(CoreControl coreControl, string buttonText);
    }
}
