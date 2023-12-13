using Measurements;

namespace MeasurementsTests.VolumeTests;

public class VolumeAdditionTests
{
    [Fact]
        public void AddVolume_SameUnit()
    {
        var volume1 = new Measurements.Volume(VolumeUnit.Milliliters, 5);
        var volume2 = new Measurements.Volume(VolumeUnit.Milliliters, 10);
        volume1.Add(volume2);
        Assert.Equal(15, volume1.Amount);
    }

    [Fact]
    public void AddVolume_DifferentUnits()
    {
        var volume1 = new Measurements.Volume(VolumeUnit.Liters, 1);
        var volume2 = new Measurements.Volume(VolumeUnit.Milliliters, 1000);
        volume1.Add(volume2);
        Assert.Equal(1, volume1.Amount);
        Assert.Contains(volume1.OtherVolumes, d => d.VolumeType == VolumeUnit.Milliliters && d.Amount == 1000);
    }

    [Fact]
    public void AddVolume_MultipleTimes()
    {
        var volume1 = new Volume(VolumeUnit.Liters, 1);
        var volume2 = new Volume(VolumeUnit.Milliliters, 1000);
        var volume3 = new Volume(VolumeUnit.CubicMeters, 3);
        volume1.Add(volume2).Add(volume3);
        Assert.Equal(1, volume1.Amount);
        Assert.Contains(volume1.OtherVolumes, d => d.VolumeType == VolumeUnit.Milliliters && d.Amount == 1000);
        Assert.Contains(volume1.OtherVolumes, d => d.VolumeType == VolumeUnit.CubicMeters && d.Amount == 3);
    }

    [Fact]
    public void AddVolume_WithOtherVolumes()
    {
        var volume1 = new Volume(VolumeUnit.Liters, 1);
        var subVolume = new Volume(VolumeUnit.Milliliters, 100);
        var volume2 = new Volume(VolumeUnit.CubicMeters, 3);
        volume2.Add(subVolume); // Add subVolume to volume2's OtherVolumes
        volume1.Add(volume2);
        Assert.Equal(1, volume1.Amount);
        Assert.Contains(volume1.OtherVolumes, d => d.VolumeType == VolumeUnit.CubicMeters && d.Amount == 3);
        Assert.Contains(volume1.OtherVolumes, d => d.VolumeType == VolumeUnit.Milliliters && d.Amount == 100);
    } 
}