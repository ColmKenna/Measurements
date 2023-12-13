using Measurements;

namespace MeasurementsTests.Weights;

public class WeightCreationTests
{
    [Fact]
    public void Milligrams_Creation_Test()
    {
        var weight = Weight.Milligrams(100);
        Assert.Equal(100, weight.GetAs(WeightUnit.Milligrams).Amount);
    }

    [Fact]
    public void Grams_Creation_Test()
    {
        var weight = Weight.Grams(50);
        Assert.Equal(50, weight.GetAs(WeightUnit.Grams).Amount);
    }

    [Fact]
    public void Kilograms_Creation_Test()
    {
        var weight = Weight.Kilograms(2);
        Assert.Equal(2, weight.GetAs(WeightUnit.Kilograms).Amount);
    }

    [Fact]
    public void MetricTons_Creation_Test()
    {
        var weight = Weight.MetricTons(1);
        Assert.Equal(1, weight.GetAs(WeightUnit.MetricTons).Amount);
    }

    [Fact]
    public void Tons_Creation_Test()
    {
        var weight = Weight.USTons(1);
        Assert.Equal(1, weight.GetAs(WeightUnit.USTons).Amount);
    }

    [Fact]
    public void Ounces_Creation_Test()
    {
        var weight = Weight.Ounces(16);
        Assert.Equal(16, weight.GetAs(WeightUnit.Ounces).Amount);
    }

    [Fact]
    public void Pounds_Creation_Test()
    {
        var weight = Weight.Pounds(10);
        Assert.Equal(10, weight.GetAs(WeightUnit.Pounds).Amount);
    }

    [Fact]
    public void Stones_Creation_Test()
    {
        var weight = Weight.Stones(5);
        Assert.Equal(5, weight.GetAs(WeightUnit.Stones).Amount);
    }
}