using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Get(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
            

        return BadRequest("Invalid Input");
    }
    private bool IsNumeric(string strNumber)
    {        
        return double.TryParse(strNumber, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out double number);  
    }

    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;
        if (decimal.TryParse(strNumber, out decimalValue))        
            return decimalValue;
        
        return 0;
    }
}
