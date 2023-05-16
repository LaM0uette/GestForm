namespace GestForm;

public abstract class Program
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

    #endregion
}