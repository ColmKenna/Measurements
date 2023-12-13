using Measurements;

namespace MeasurementsTests.DurationTests;

public class DurationAdditionTests
{
    [Fact]
    public void CreateDays()
    {
        var duration1 = Duration.Days(5);

        Assert.Equal(TimeUnit.Days, duration1.Time);
        Assert.Equal(5, duration1.Units);
    }

    [Fact]
    public void CreateWeeks()
    {
        var duration1 = Duration.Weeks(5);

        Assert.Equal(TimeUnit.Weeks, duration1.Time);
        Assert.Equal(5, duration1.Units);
    }

    [Fact]
    public void CreateMonths()
    {
        var duration1 = Duration.Months(5);

        Assert.Equal(TimeUnit.Months, duration1.Time);
        Assert.Equal(5, duration1.Units);
    }

    [Fact]
    public void CreateQuarters()
    {
        var duration1 = Duration.Quarters(5);

        Assert.Equal(TimeUnit.Quarters, duration1.Time);
        Assert.Equal(5, duration1.Units);
    }

    [Fact]
    public void CreateYears()
    {
        var duration1 = Duration.Years(5);

        Assert.Equal(TimeUnit.Years, duration1.Time);
        Assert.Equal(5, duration1.Units);
    }

    [Fact]
    public void CreateHours()
    {
        var duration1 = Duration.Hours(5);

        Assert.Equal(TimeUnit.Hours, duration1.Time);
        Assert.Equal(5, duration1.Units);
    }

}