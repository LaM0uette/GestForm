using System.Diagnostics.CodeAnalysis;
using GestForm.DivisibilityRules;
using GestForm.RandomNumbers;

namespace GestForm;

public static class Program
{
    #region Statements

    private static readonly Random _randomGenerator = new();
    private static readonly IDivisibilityRule[] _rules = 
    {
        new DivisibleByThreeAndFiveRule(),
        new DivisibleByThreeRule(),
        new DivisibleByFiveRule()
    };

    #endregion

    #region Functions

    [ExcludeFromCodeCoverage]
    public static async Task Main()
    {
        var randomNumbersParams = GenerateRandomNumbersParams(-1000, 1000, 50);
        var numbers = GenerateRandomNumbers(randomNumbersParams);
        
        foreach (var number in numbers) await PrintMessageAsync(number);

        WaitForExitProgram();
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
        var randomNumbers = new List<int>();

        for (var i = 0; i < randomNumbersParams.Count; i++)
        {
            randomNumbers.Add(_randomGenerator.Next(randomNumbersParams.LowerLimit, randomNumbersParams.UpperLimit + 1));
        }

        return randomNumbers;
    }

    [ExcludeFromCodeCoverage]
    private static async Task PrintMessageAsync(int number)
    {
        var message = GetMessageForNumber(number);
        await Console.Out.WriteLineAsync(message);
    }
    
    public static string GetMessageForNumber(int number)
    {
        // Loop on all rules and check if number is divisible
        foreach (var rule in _rules.Where(rule => rule.IsDivisible(number)))
        {
            return rule.MessageForDivisibleNumbers;
        }

        // If no rule applies, returns number converted to string
        return number.ToString();
    }

    [ExcludeFromCodeCoverage]
    private static void WaitForExitProgram()
    {
#if !DEBUG
        Console.Write("Appuyer sur Entrée pour quitter...");
        Console.ReadKey();
#endif
    }
        
    #endregion
}