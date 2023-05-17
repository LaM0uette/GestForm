using GestForm.DivisibilityRules;

namespace GestForm;

public class Program
{
    #region Statements

    public struct RandomParams
    {
        public int LowerLimit;
        public int UpperLimit;
        public int Count;
    }
    
    private static readonly List<IDivisibilityRule> rules = new()
    {
        new DivisibleByThreeAndFiveRule(),
        new DivisibleByThreeRule(),
        new DivisibleByFiveRule()
    };

    #endregion

    #region Functions

    public static void Main()
    {
        var randomParams = GenerateRandomParams(-1000, 1000, 50);
        var numbers = GenerateRandomNumbers(randomParams);

        // Afficher le message pour chaque nombre
        foreach (var number in numbers)
        {
            Console.WriteLine(GetMessageForNumber(number));
        }
    }

    public static RandomParams GenerateRandomParams(int lowerLimit, int upperLimit, int count)
    {
        return new RandomParams
        {
            LowerLimit = lowerLimit,
            UpperLimit = upperLimit,
            Count = count
        };
    }

    public static IEnumerable<int> GenerateRandomNumbers(RandomParams randomParams)
    {
        var randomGenerator = new Random();
        var randomNumbers = new List<int>();

        for (var i = 0; i < randomParams.Count; i++)
        {
            randomNumbers.Add(randomGenerator.Next(randomParams.LowerLimit, randomParams.UpperLimit + 1));
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