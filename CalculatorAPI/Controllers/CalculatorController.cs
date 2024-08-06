using CalculatorCore;
using CalculatorCore.Clicks;
using CalculatorCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPI.Controllers
{
    /// <summary>
    /// The CalculatorController class is responsible for handling API requests to the calculator,
    /// mapping button texts to their corresponding click actions, and managing the overall calculator logic.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        /// <summary>
        /// Dictionary to map button text to the corresponding IClick implementation.
        /// </summary>
        private readonly Dictionary<string, IClick> buttonText2Click = new()
        {
            { "1", new DigitDotClick() },
            { "2", new DigitDotClick() },
            { "3", new DigitDotClick() },
            { "4", new DigitDotClick() },
            { "5", new DigitDotClick() },
            { "6", new DigitDotClick() },
            { "7", new DigitDotClick() },
            { "8", new DigitDotClick() },
            { "9", new DigitDotClick() },
            { "0", new DigitDotClick() },
            { ".", new DigitDotClick() },
            { "+", new OperatorClick() },
            { "-", new OperatorClick() },
            { "×", new OperatorClick() },
            { "÷", new OperatorClick() },
            { "%", new OperatorClick() },
            { "^", new OperatorClick() },
            { "(", new LeftParenthesisClick() },
            { ")", new RightParenthesisClick() },
            { "√", new SquareRootClick() },
            { "=", new EqualClick() },
            { "C", new ClearClick() },
            { "CE", new ClearEntryClick() },
            { "Backspace", new BackspaceClick() },
            { "±", new NegateClick() }
        };

        private readonly ILogger<CalculatorController> _logger;
        private readonly CoreControl CoreController;

        /// <summary>
        /// Initializes a new instance of the CalculatorController class.
        /// </summary>
        /// <param name="logger">Logger instance for logging.</param>
        /// <param name="coreController">Core controller for calculator logic.</param>
        public CalculatorController(ILogger<CalculatorController> logger, CoreControl coreController)
        {
            _logger = logger;
            CoreController = coreController;
        }

        /// <summary>
        /// Handles POST requests to perform calculator actions based on button text input.
        /// </summary>
        /// <param name="buttonText">The text of the calculator button pressed.</param>
        /// <returns>An IActionResult that is either Ok with the result or BadRequest on invalid input.</returns>
        [HttpPost(Name = "PostCalculator")]
        public IActionResult Post([FromBody] string buttonText)
        {
            try
            {
                return Ok(buttonText2Click[buttonText].Click(CoreController, buttonText));
            }
            catch
            {
                return BadRequest("Invalid button text specified.");
            }
        }
    }
}
