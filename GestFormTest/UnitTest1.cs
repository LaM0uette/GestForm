using GestForm;

namespace GestFormTest;

public class UnitTest1
{
    private readonly Program.RandomParams _randomParams = new()
    {
        Lower = -1000,
        Upper = 1000,
        Count = 50
    };
        
    [Fact]
    public void GenerateRandomNumbers_CountEqual50_50()
    {
        var result = Program.GenerateRandomNumbers(_randomParams);
        Assert.Equal(_randomParams.Count, result.Count());
    }
}