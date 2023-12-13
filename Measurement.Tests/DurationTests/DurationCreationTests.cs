using Measurements;

namespace MeasurementsTests.DurationTests;

public class DurationCreationTests
{
    [Fact]
    public void AddDuration_SameUnit()
    {
        var duration1 = Duration.Days(5);
        var duration2 = Duration.Days(10);
        duration1.Add(duration2);
        Assert.Equal(15, duration1.Units);
    }

    [Fact]
    public void AddDuration_DifferentUnits()
    {
        var duration1 = Duration.Hours(1);
        var duration2 = Duration.Days(1);
        duration1.Add(duration2);

        Assert.Equal(25, duration1.GetAs(TimeUnit.Hours).Units);
    }

    [Fact]
    public void AddDuration_WithOperator_CreatesNewDuration_AndLeavesOriginalUntouched()
    {
        var duration1 = Duration.Days(5);
        var duration2 = Duration.Days(10);
        var result = duration1 + duration2;
        Assert.Equal(15, result.Units);
        Assert.Equal(5, duration1.Units);
        Assert.Equal(10, duration2.Units);
    }
}