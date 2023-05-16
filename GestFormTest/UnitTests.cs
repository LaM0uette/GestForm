using GestForm;

namespace GestFormTest;

public class UnitTests
{
    private readonly Program.RandomParams _randomParams = new()
    {
        LowerLimit = -1000,
        UpperLimit = 1000,
        Count = 50
    };
        
    [Fact]
    public void GenerateRandomNumbers_CountEqual50_50()
    {
        var result = Program.GenerateRandomNumbers(_randomParams);
        Assert.Equal(_randomParams.Count, result.Count());
    }
    
    [Fact]
    public void GenerateRandomNumbers_ReturnsNumbersWithinLimits()
    {
        var result = Program.GenerateRandomNumbers(_randomParams);
        Assert.True(result.All(n => n >= _randomParams.LowerLimit && n <= _randomParams.UpperLimit));
    }
}