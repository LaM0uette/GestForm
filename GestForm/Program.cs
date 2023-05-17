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

        // Afficher le message pour chaque nombre
        foreach (var number in numbers)
        {
            Console.WriteLine(GetMessageForNumber(number));
        }
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

    public static string GetMessageForNumber(int number)
    {
        foreach (var rule in rules.Where(rule => rule.IsDivisible(number)))
        {
            return rule.MessageForDivisibleNumbers;
        }

        return number.ToString();
    }

    #endregion
}