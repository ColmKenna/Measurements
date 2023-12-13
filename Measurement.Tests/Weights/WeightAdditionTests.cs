using Measurements;

namespace MeasurementsTests.Weights;

public class WeightAdditionTests
{
    [Fact]
    public void Add_Milligrams_To_Milligrams()
    {
        var weight1 = Weight.Milligrams(100);
        var weight2 = Weight.Milligrams(150);
        var result = weight1 + weight2;

        Assert.Equal(250, result.GetAs(WeightUnit.Milligrams).Amount);
    }

    [Fact]
    public void Add_Grams_To_Grams()
    {
        var weight1 = Weight.Grams(50);
        var weight2 = Weight.Grams(25);
        var result = weight1 + weight2;

        Assert.Equal(75, result.GetAs(WeightUnit.Grams).Amount);
    }

    [Fact]
    public void Add_Kilograms_To_Kilograms()
    {
        var weight1 = Weight.Kilograms(2);
        var weight2 = Weight.Kilograms(3);
        var result = weight1 + weight2;

        Assert.Equal(5, result.GetAs(WeightUnit.Kilograms).Amount);
    }

    [Fact]
    public void Add_MetricTons_To_MetricTons()
    {
        var weight1 = Weight.MetricTons(1);
        var weight2 = Weight.MetricTons(2);
        var result = weight1 + weight2;

        Assert.Equal(3, result.GetAs(WeightUnit.MetricTons).Amount);
    }

    [Fact]
    public void Add_Ounces_To_Ounces()
    {
        var weight1 = Weight.Ounces(16);
        var weight2 = Weight.Ounces(32);
        var result = weight1 + weight2;

        Assert.Equal(48, result.GetAs(WeightUnit.Ounces).Amount);
    }


    [Fact]
    public void Add_Different_Units()
    {
        var weight1 = Weight.Grams(500); // 500 grams
        var weight2 = Weight.Kilograms(1); // 1 kilogram
        var result = weight1 + weight2;

        Assert.Equal(1.5m, result.GetAs(WeightUnit.Kilograms).Amount); // 1.5 kilograms
    }


    [Fact]
    public void Add_Pounds_To_Pounds()
    {
        var weight1 = Weight.Pounds(10);
        var weight2 = Weight.Pounds(20);
        var result = weight1 + weight2;

        Assert.Equal(30, result.GetAs(WeightUnit.Pounds).Amount);
    }

    [Fact]
    public void Add_Stones_To_Stones()
    {
        var weight1 = Weight.Stones(5);
        var weight2 = Weight.Stones(7);
        var result = weight1 + weight2;

        Assert.Equal(12, result.GetAs(WeightUnit.Stones).Amount);
    }

    [Fact]
    public void Add_Tons_To_Tons()
    {
        var weight1 = Weight.USTons(3);
        var weight2 = Weight.USTons(2);
        var result = weight1 + weight2;

        Assert.Equal(5, result.GetAs(WeightUnit.USTons).Amount);
    }

    [Fact]
    public void Add_Milligrams_To_Grams()
    {
        var weight1 = Weight.Milligrams(2000); // 2000 milligrams
        var weight2 = Weight.Grams(1); // 1 gram
        var result = weight1 + weight2;

        Assert.Equal(3, result.GetAs(WeightUnit.Grams).Amount); // 3 grams
    }

    [Fact]
    public void Add_Grams_To_Kilograms()
    {
        var weight1 = Weight.Grams(500); // 500 grams
        var weight2 = Weight.Kilograms(1); // 1 kilogram
        var result = weight1 + weight2;

        Assert.Equal(1.5m, result.GetAs(WeightUnit.Kilograms).Amount); // 1.5 kilograms
    }

    [Fact]
    public void Add_Kilograms_To_MetricTons()
    {
        var weight1 = Weight.Kilograms(500); // 500 kilograms
        var weight2 = Weight.MetricTons(1); // 1 metric ton
        var result = weight1 + weight2;

        Assert.Equal(1.5m, result.GetAs(WeightUnit.MetricTons).Amount); // 1.5 metric tons
    }

    [Fact]
    public void Add_Ounces_To_Pounds()
    {
        var weight1 = Weight.Ounces(16); // 16 ounces
        var weight2 = Weight.Pounds(1); // 1 pound
        var result = weight1 + weight2;

        Assert.Equal(2, result.GetAs(WeightUnit.Pounds).Amount); // 2 pounds
    }
    
    [Fact]
    public void Add_Pounds_To_Stones()
    {
        var weight1 = Weight.Pounds(14); // 14 pounds
        var weight2 = Weight.Stones(1); // 1 stone
        var result = weight1 + weight2;

        Assert.Equal(2, result.GetAs(WeightUnit.Stones).Amount); // 2 stones
    }
   
    
    [Fact]
    public void Add_Milligrams_To_Kilograms()
    {
        var weight1 = Weight.Milligrams(2000); // 2000 milligrams
        var weight2 = Weight.Kilograms(1); // 1 kilogram
        var result = weight1 + weight2;

        Assert.Equal(1.002m, result.GetAs(WeightUnit.Kilograms).Amount); // 2.002 kilograms
    }

    [Fact]
    public void WhenAddingWeightWithSubWeightsThenSimplify()
    {
        var weight = Weight.Kilograms(2); // 2000 milligrams
        var weight1 = Weight.Milligrams(2000); // 2000 milligrams
        var weight2 = Weight.Kilograms(1); // 1 kilogram

        var result = weight.Add(weight1);
        result = result.Add(weight2);
        
        Assert.Equal(3, result.Amount); // 2 kilograms
        Assert.Single(result.OtherWeights);
        Assert.Equal(2000, result.OtherWeights[0].Amount); // 2000 milligrams
        
        

    }
    
    
}