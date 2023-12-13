using Measurements;

namespace MeasurementsTests.VolumeTests;

public class VolumeCreationTests{
    [Fact]
    public void CreateMillilitersTest()
    {
        var volume = Volume.Milliliters(5);
        Assert.Equal(VolumeUnit.Milliliters, volume.VolumeType);
        Assert.Equal(5, volume.GetAs(VolumeUnit.Milliliters).Amount );
    }

    [Fact]
    public void CreateCentilitersTest()
    {
        var volume = Volume.CubicCentimeters(10);
        Assert.Equal(VolumeUnit.CubicCentimeters, volume.VolumeType);
        Assert.Equal(10, volume.GetAs(VolumeUnit.CubicCentimeters).Amount);
    }

    [Fact]
    public void CreateLitersTest()
    {
        var volume = Volume.Liters(1);
        Assert.Equal(VolumeUnit.Liters, volume.VolumeType);
        Assert.Equal(1, volume.GetAs(VolumeUnit.Liters).Amount);
    }

    [Fact]
    public void CreateCubicMetersTest()
    {
        var volume = Volume.CubicMeters(2);
        Assert.Equal(VolumeUnit.CubicMeters, volume.VolumeType);
        Assert.Equal(2, volume.GetAs(VolumeUnit.CubicMeters).Amount);
    }

    [Fact]
    public void CreateCubicInchesTest()
    {
        var volume = Volume.CubicInches(12);
        Assert.Equal(VolumeUnit.CubicInches, volume.VolumeType);
        Assert.Equal(12, volume.GetAs(VolumeUnit.CubicInches).Amount);
    }

    [Fact]
    public void CreateCubicFeetTest()
    {
        var volume = Volume.CubicFeet(3);
        Assert.Equal(VolumeUnit.CubicFeet, volume.VolumeType);
        Assert.Equal(3, volume.GetAs(VolumeUnit.CubicFeet).Amount);
    }

    [Fact]
    public void CreateCubicYardsTest()
    {
        var volume = Volume.CubicYards(4);
        Assert.Equal(VolumeUnit.CubicYards, volume.VolumeType);
        Assert.Equal(4, volume.GetAs(VolumeUnit.CubicYards).Amount);
    }

}