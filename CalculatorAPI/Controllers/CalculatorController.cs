using CalculatorCore;
using CalculatorCore.Clicks;
using CalculatorCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
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
        public CalculatorController(ILogger<CalculatorController> logger, CoreControl coreController, UIContext formContext)
        {
            _logger = logger;
            CoreController = coreController;
        }
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