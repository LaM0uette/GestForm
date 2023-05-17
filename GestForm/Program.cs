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
    
    private static List<IDivisibilityRule> rules = new()
    {
        new DivisibleByThreeAndFiveRule(),
        new DivisibleByThreeRule(),
        new DivisibleByFiveRule()
    };

    #endregion

    #region Functions

    public static void Main()
    {
        // Création des paramètres de nombres aléatoires
        var randomParam = new RandomParams
        {
            LowerLimit = -1000,
            UpperLimit = 1000,
            Count = 50
        };
        
        // Générer des nombres aléatoires
        var numbers = GenerateRandomNumbers(randomParam);

        // Afficher le message pour chaque nombre
        foreach (var number in numbers)
        {
            Console.WriteLine(GetMessageForNumber(number));
        }
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