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

    [Fact]
    public void GetMessageForNumber_1_1()
    {
        var message = Program.GetMessageForNumber(1);
        Assert.Equal("1", message);
    }
    
    [Fact]
    public void GetMessageForNumber_2_2()
    {
        var message = Program.GetMessageForNumber(2);
        Assert.Equal("2", message);
    }
    
    [Fact]
    public void GetMessageForNumber_3_Gest()
    {
        var message = Program.GetMessageForNumber(3);
        Assert.Equal("Geste", message);
    }
    
    [Fact]
    public void GetMessageForNumber_5_Form()
    {
        var message = Program.GetMessageForNumber(5);
        Assert.Equal("Forme", message);
    }
    
    [Fact]
    public void GetMessageForNumber_15_Form()
    {
        var message = Program.GetMessageForNumber(15);
        Assert.Equal("GestForm", message);
    }
}