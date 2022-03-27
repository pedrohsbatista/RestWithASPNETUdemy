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
    public IActionResult GetSum(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult GetSubtraction(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sub.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult GetMultiplication(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var mul = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(mul.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult GetDivision(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(div.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("average/{numbers}")]
    public IActionResult GetAverage(string numbers)
    {
        try
        {
            var numbersInput = numbers.Split(';');
            var numbersOutput = new decimal[numbersInput.Length];
            for (var i = 0; i < numbersInput.Length; i++)
            {
                var number = numbersInput[i];
                if (IsNumeric(number))
                    numbersOutput[i] = ConvertToDecimal(number);
                else
                    throw new Exception();
            }
                        
            var avg = numbersOutput.Average();
            return Ok(avg.ToString());
        }
        catch (Exception)
        {
            return BadRequest("Invalid Input");
        }
    }

    [HttpGet("squareroot/{number}")]
    public IActionResult GetSquareRoot(string number)
    {
        if (IsNumeric(number))
        {
            var squareRoot = Math.Sqrt(ConvertToDouble(number));
            return Ok(squareRoot.ToString());
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
    
    private double ConvertToDouble(string strNumber)
    {
        if (double.TryParse(strNumber, out var number))
            return number;
        else
            return 0;
    }
}
