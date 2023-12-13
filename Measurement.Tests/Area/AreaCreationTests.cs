using Measurements;

namespace MeasurementsTests.AreaTests;

public class AreaCreationTests
{
    [Fact]
    public void CreateSquareMillimetersTest()
    {
        var area = Area.SquareMillimeters(5);
        Assert.Equal(AreaUnit.SquareMillimeters, area.AreaType);
        Assert.Equal(5, area.GetAs(AreaUnit.SquareMillimeters).Amount);
    }
    
    [Fact]
    public void CreateSquareCentimetersTest()
    {
        var area = Area.SquareCentimeters(10);
        Assert.Equal(AreaUnit.SquareCentimeters, area.AreaType);
        Assert.Equal(10, area.GetAs(AreaUnit.SquareCentimeters).Amount);
    }
    
    [Fact]
    public void CreateSquareMetersTest()
    {
        var area = Area.SquareMeters(1);
        Assert.Equal(AreaUnit.SquareMeters, area.AreaType);
        Assert.Equal(1, area.GetAs(AreaUnit.SquareMeters).Amount);
    }
    
    [Fact]
    public void CreateSquareKilometersTest()
    {
        var area = Area.SquareKilometers(2);
        Assert.Equal(AreaUnit.SquareKilometers, area.AreaType);
        Assert.Equal(2, area.GetAs(AreaUnit.SquareKilometers).Amount);
    }
    
    [Fact]
    public void CreateSquareInchesTest()
    {
        var area = Area.SquareInches(12);
        Assert.Equal(AreaUnit.SquareInches, area.AreaType);
        Assert.Equal(12, area.GetAs(AreaUnit.SquareInches).Amount);
    }
    
    [Fact]
    public void CreateSquareFeetTest()
    {
        var area = Area.SquareFeet(3);
        Assert.Equal(AreaUnit.SquareFeet, area.AreaType);
        Assert.Equal(3, area.GetAs(AreaUnit.SquareFeet).Amount);
    }
    
    [Fact]
    public void CreateSquareYardsTest()
    {
        var area = Area.SquareYards(4);
        Assert.Equal(AreaUnit.SquareYards, area.AreaType);
        Assert.Equal(4, area.GetAs(AreaUnit.SquareYards).Amount);
    }
    
    [Fact]
    public void CreateAcresTest()
    {
        var area = Area.Acres(5);
        Assert.Equal(AreaUnit.Acres, area.AreaType);
        Assert.Equal(5, area.GetAs(AreaUnit.Acres).Amount);
    }
    
    [Fact]
    public void CreateSquareMilesTest()
    {
        var area = Area.SquareMiles(6);
        Assert.Equal(AreaUnit.SquareMiles, area.AreaType);
        Assert.Equal(6, area.GetAs(AreaUnit.SquareMiles).Amount);
    }
    
}