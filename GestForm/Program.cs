using System.Diagnostics.CodeAnalysis;
using GestForm.DivisibilityRules;
using GestForm.RandomNumbers;

namespace GestForm;

public static class Program
{
    #region Statements

    private static readonly List<IDivisibilityRule> rules = new()
    {
        new DivisibleByThreeAndFiveRule(),
        new DivisibleByThreeRule(),
        new DivisibleByFiveRule()
    };

    #endregion

    #region Functions

    [ExcludeFromCodeCoverage]
    public static void Main()
    {
        var randomNumbersParams = GenerateRandomNumbersParams(-1000, 1000, 50);
        var numbers = GenerateRandomNumbers(randomNumbersParams);
        
        foreach (var number in numbers) PrintMessage(number);
    }

    public static RandomNumbersParams GenerateRandomNumbersParams(int lowerLimit, int upperLimit, int count)
    {
        return new RandomNumbersParams
        {
            LowerLimit = lowerLimit,
            UpperLimit = upperLimit,
            Count = count
        };
    }

    public static IEnumerable<int> GenerateRandomNumbers(RandomNumbersParams randomNumbersParams)
    {
        var randomGenerator = new Random();
        var randomNumbers = new List<int>();

        for (var i = 0; i < randomNumbersParams.Count; i++)
        {
            randomNumbers.Add(randomGenerator.Next(randomNumbersParams.LowerLimit, randomNumbersParams.UpperLimit + 1));
        }

        return randomNumbers;
    }

    [ExcludeFromCodeCoverage]
    private static void PrintMessage(int number)
    {
        var message = GetMessageForNumber(number);
        Console.WriteLine(message);
    }
    
    public static string GetMessageForNumber(int number)
    {
        // Loop on all rules and check if number is divisible
        foreach (var rule in rules.Where(rule => rule.IsDivisible(number)))
        {
            return rule.MessageForDivisibleNumbers;
        }

        // If no rule applies, returns number converted to string
        return number.ToString();
    }

    #endregion
}