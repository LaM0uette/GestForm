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

    #endregion

    #region Functions

    public static void Main()
    {
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
        var message = number.ToString();

        if ((number % 3).Equals(0) && (number % 5).Equals(0)) message = "GestForm";
        else if ((number % 3).Equals(0)) message = "Gest";
        else if ((number % 5).Equals(0)) message = "Form";
        
        return message;
    }

    #endregion
}