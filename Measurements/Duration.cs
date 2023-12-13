using PrimativeExtensions;

namespace Measurements;

public class Duration : IUnitOfMeasurement<Duration, (TimeUnit durationUnit, DateTime? date)>
{
    public TimeUnit Time { get; }
    public int Units { get; private set; }
    public List<Duration> OtherDurations { get; } = new();

    public Duration(TimeUnit time, int units)
    {
        Time = time;
        Units = units;
    }

    public Duration Add(Duration value)
    {
        if (value.OtherDurations.Any())
        {
            foreach (var otherDuration in value.OtherDurations)
            {
                Add(otherDuration);
            }
        }

        if (value.Time == Time)
        {
            Units += value.Units;
            return this;
        }

        this.OtherDurations.Add(new Duration(value.Time, value.Units));
        return this;
    }


    public Duration DeepClone()
    {
        var newDuration = new Duration(Time, Units);
        foreach (var otherDuration in OtherDurations)
        {
            newDuration.Add(otherDuration.DeepClone());
        }

        return newDuration;
    }
    
    public static Duration operator +(Duration a, Duration b)
    {

        var newDuration = a.DeepClone();
        var newDuration2 = b.DeepClone();
        return newDuration.Add(newDuration2);
    }
    
    
    public IEnumerable<Duration> OtherDurationsRecursive()
    {
        foreach (var otherDuration in OtherDurations)
        {
            yield return otherDuration;
            foreach (var otherDurationAndTheirOtherDuration in otherDuration.OtherDurationsRecursive())
            {
                yield return otherDurationAndTheirOtherDuration;
            }
        }
    }

    public Duration GetAs(TimeUnit conversionSpec)
    {

        return GetAs((conversionSpec, null));
    }

    
    public Duration GetAs((TimeUnit durationUnit, DateTime? date) conversionSpec)
    {
        Duration newDuration = (Time == conversionSpec.durationUnit) ? this : ConvertCurrent(conversionSpec);
        if (OtherDurations.Count == 0)
            return newDuration;

        var runningTotal = newDuration.Units;
        foreach (var otherDuration in OtherDurations)
        {
            runningTotal += otherDuration.GetAs(conversionSpec).Units;
        }

        return new Duration(conversionSpec.durationUnit, runningTotal);
    }

    private Duration ConvertCurrent((TimeUnit durationUnit, DateTime? date) conversionSpec)
    {
        return ConvertTo(conversionSpec.durationUnit, conversionSpec.date); 
    }

    public Duration ConvertTo(TimeUnit toUnit, DateTime? date = null)
    {
        Func<int> getDaysInMonth = () => DateTime.DaysInMonth(date.Value.Year, date.Value.Month);
        Func<int> getDaysInYear = () => DateTime.IsLeapYear(date.Value.Year) ? 366 : 365;
        Func<int> getDaysInQuarter = () => (date.Value.AddMonths(3) - date.Value).Days;
        DateTime endDate;
        switch (toUnit)
        {
            case TimeUnit.Hours:
                switch (Time)
                {
                    case TimeUnit.Hours:
                        return new Duration(TimeUnit.Hours, Units);
                    case TimeUnit.Days:
                        return new Duration(TimeUnit.Hours, Units * 24);
                    case TimeUnit.Weeks:
                        return new Duration(TimeUnit.Hours, Units * 24 * 7);
                    case TimeUnit.Months:
                        endDate = date.Value.AddMonths(Units);
                        return Duration.Hours((endDate - date.Value).TotalHours.ToInt());
                    case TimeUnit.Years:
                        endDate = date.Value.AddYears(Units);
                        return Duration.Hours((endDate - date.Value).TotalHours.ToInt());
                    case TimeUnit.Quarters:
                        endDate = date.Value.AddMonths(Units * 3);
                        return Duration.Hours((endDate - date.Value).TotalHours.ToInt());
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case TimeUnit.Days:
                switch (Time)
                {
                    case TimeUnit.Hours:
                        var days = Units / 24;
                        var remainder = Units % 24;
                        if (remainder > 0)
                        {
                            return new Duration(TimeUnit.Days, days) + new Duration(TimeUnit.Hours, remainder);
                        }

                        return new Duration(TimeUnit.Days, Units / 24);
                    case TimeUnit.Days:
                        return new Duration(TimeUnit.Days, Units);
                    case TimeUnit.Weeks:
                        return new Duration(TimeUnit.Days, Units * 7);
                    case TimeUnit.Months:
                        endDate = date.Value.AddMonths(Units);

                        return Duration.Days((endDate - date.Value).TotalDays.ToInt());
                    case TimeUnit.Years:
                        endDate = date.Value.AddYears(Units);
                        var daysFromYears = (endDate.Year - date.Value.Year) * 12 + endDate.Month - date.Value.Month;
                        return Duration.Days((endDate - date.Value).TotalDays.ToInt());
                    case TimeUnit.Quarters:
                        endDate = date.Value.AddMonths(Units * 3);
                        var daysFromQuarters = (endDate.Year - date.Value.Year) * 12 + endDate.Month - date.Value.Month;
                        return Duration.Days((endDate - date.Value).TotalDays.ToInt());
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case TimeUnit.Weeks:
                switch (Time)
                {
                    case TimeUnit.Hours:
                        var weeks = Units / (24 * 7);
                        var remainder = Units % (24 * 7);
                        if (remainder > 0)
                        {
                            return new Duration(TimeUnit.Weeks, weeks) + new Duration(TimeUnit.Hours, remainder);
                        }

                        return new Duration(TimeUnit.Weeks, weeks);
                    case TimeUnit.Days:
                        var remainderDays = Units % 7;
                        if (remainderDays > 0)
                        {
                            return new Duration(TimeUnit.Weeks, Units / 7) + new Duration(TimeUnit.Days, remainderDays);
                        }

                        return new Duration(TimeUnit.Weeks, Units / 7);
                    case TimeUnit.Weeks:
                        return new Duration(TimeUnit.Weeks, Units);
                    case TimeUnit.Months:
                        endDate = date.Value.AddMonths(Units);
                        return Duration.Days((endDate - date.Value).TotalDays.ToInt()).ConvertTo(TimeUnit.Weeks, date);
                    case TimeUnit.Years:
                        endDate = date.Value.AddYears(Units);
                        return Duration.Days((endDate - date.Value).TotalDays.ToInt()).ConvertTo(TimeUnit.Weeks, date);
                    case TimeUnit.Quarters:
                        endDate = date.Value.AddMonths(Units * 3);
                        return Duration.Days((endDate - date.Value).TotalDays.ToInt()).ConvertTo(TimeUnit.Weeks, date);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case TimeUnit.Months:
                switch (Time)
                {
                    case TimeUnit.Hours:
                        endDate = date.Value.AddHours(Units);
                        var months = (endDate.Year - date.Value.Year) * 12 + endDate.Month - date.Value.Month;
                        var remainderHours = (endDate - date.Value.AddMonths(months)).TotalHours.ToInt();
                        if (remainderHours > 0)
                        {
                            return new Duration(TimeUnit.Months, months) + new Duration(TimeUnit.Hours, remainderHours);
                        }

                        return new Duration(TimeUnit.Months, months);
                    case TimeUnit.Days:
                        endDate = date.Value.AddDays(Units);
                        // get the number of months rounded between the start and end date
                        var monthsFromDays = (endDate.Year - date.Value.Year) * 12 + endDate.Month - date.Value.Month;
                        // get the remainder days
                        var remainderDays = (endDate - date.Value.AddMonths(monthsFromDays)).TotalDays.ToInt();
                        if (remainderDays > 0)
                        {
                            return new Duration(TimeUnit.Months, monthsFromDays) +
                                   new Duration(TimeUnit.Days, remainderDays);
                        }

                        return new Duration(TimeUnit.Months, monthsFromDays);
                    case TimeUnit.Weeks:
                        endDate = date.Value.AddDays(Units * 7);
                        // get the number of months rounded between the start and end date
                        var monthsFromWeeks = (endDate.Year - date.Value.Year) * 12 + endDate.Month - date.Value.Month;
                        var remainderDays1 = (endDate - date.Value.AddMonths(monthsFromWeeks)).TotalDays.ToInt();
                        var remainderWeeks = Duration.Days(remainderDays1).ConvertTo(TimeUnit.Weeks);


                        if (remainderDays1 > 0)
                        {
                            return new Duration(TimeUnit.Months, monthsFromWeeks) + remainderWeeks;
                        }

                        return new Duration(TimeUnit.Months, monthsFromWeeks);
                    case TimeUnit.Months:
                        return new Duration(TimeUnit.Months, Units);
                    case TimeUnit.Years:
                        return new Duration(TimeUnit.Months, Units * 12);
                    case TimeUnit.Quarters:
                        return new Duration(TimeUnit.Months, Units * 3);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case TimeUnit.Years:
                switch (Time)
                {
                    case TimeUnit.Hours:
                        endDate = date.Value.AddHours(Units);
                        var yearsFromHours = (endDate.Year - date.Value.Year);
                        var remainderHours = (endDate - date.Value.AddYears(yearsFromHours)).TotalHours.ToInt();

                        if (remainderHours > 0)
                        {
                            return new Duration(TimeUnit.Years, yearsFromHours) +
                                   new Duration(TimeUnit.Hours, remainderHours);
                        }

                        return new Duration(TimeUnit.Years, yearsFromHours);
                    case TimeUnit.Days:
                        endDate = date.Value.AddDays(Units);
                        var yearsFromDays = (endDate.Year - date.Value.Year);
                        var remainderDays = (endDate - date.Value.AddYears(yearsFromDays)).TotalDays.ToInt();

                        if (remainderDays > 0)
                        {
                            return new Duration(TimeUnit.Years, yearsFromDays) +
                                   new Duration(TimeUnit.Days, remainderDays);
                        }

                        return new Duration(TimeUnit.Years, yearsFromDays);
                    case TimeUnit.Weeks:
                        endDate = date.Value.AddDays(Units * 7);
                        var yearsFromWeeks = (endDate.Year - date.Value.Year);
                        var endOfYears1 = date.Value.AddYears(yearsFromWeeks);

                        var remainderWeeks = Duration.Days((endDate - endOfYears1).TotalDays.ToInt())
                            .ConvertTo(TimeUnit.Weeks, endOfYears1);

                        if ((endDate - endOfYears1).TotalDays.ToInt() > 0)
                        {
                            return new Duration(TimeUnit.Years, yearsFromWeeks) + remainderWeeks;
                        }

                        return new Duration(TimeUnit.Years, yearsFromWeeks);
                    case TimeUnit.Months:
                        endDate = date.Value.AddMonths(Units);

                        var yearsFromMonths = (endDate.Year - date.Value.Year);
                        var endOfYears = date.Value.AddYears(yearsFromMonths);


                        var remainderMonths = Duration.Days((endDate - endOfYears).TotalDays.ToInt())
                            .ConvertTo(TimeUnit.Months, endOfYears);

                        if ((endDate - endOfYears).TotalDays.ToInt() > 0)
                        {
                            return new Duration(TimeUnit.Years, yearsFromMonths) + remainderMonths;
                        }

                        return new Duration(TimeUnit.Years, yearsFromMonths);
                    case TimeUnit.Quarters:
                        var yearsFromQuarters = Units / 4;
                        var remainderQuarters = Units % 4;
                        if (remainderQuarters > 0)
                        {
                            return new Duration(TimeUnit.Years, yearsFromQuarters) +
                                   new Duration(TimeUnit.Quarters, remainderQuarters);
                        }

                        return new Duration(TimeUnit.Years, yearsFromQuarters);
                    case TimeUnit.Years:
                        return new Duration(TimeUnit.Years, Units);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case TimeUnit.Quarters:
                switch (Time)
                {
                    case TimeUnit.Hours:
                        endDate = date.Value.AddHours(Units);
                        var quartersFromHours = (endDate.Year - date.Value.Year) * 4 +
                                                (endDate.Month - date.Value.Month) / 3;
                        var remainderHours = (endDate - date.Value.AddMonths(quartersFromHours * 3)).TotalHours.ToInt();

                        if (remainderHours > 0)
                        {
                            return new Duration(TimeUnit.Quarters, quartersFromHours) +
                                   new Duration(TimeUnit.Hours, remainderHours);
                        }

                        return new Duration(TimeUnit.Quarters, quartersFromHours);
                    case TimeUnit.Days:
                        endDate = date.Value.AddDays(Units);
                        var quartersFromDays = (endDate.Year - date.Value.Year) * 4 +
                                               (endDate.Month - date.Value.Month) / 3;
                        var remainderDays = (endDate - date.Value.AddMonths(quartersFromDays * 3)).TotalDays.ToInt();


                        if (remainderDays > 0)
                        {
                            return new Duration(TimeUnit.Quarters, quartersFromDays) +
                                   new Duration(TimeUnit.Days, remainderDays);
                        }

                        return new Duration(TimeUnit.Quarters, quartersFromDays);
                    case TimeUnit.Weeks:
                        endDate = date.Value.AddDays(Units * 7);
                        var quartersFromWeeks = (endDate.Year - date.Value.Year) * 4 +
                                                (endDate.Month - date.Value.Month) / 3;
                        var remainderWeeks = (endDate - date.Value.AddMonths(quartersFromWeeks * 3)).TotalDays.ToInt() /
                                             7;

                        if (remainderWeeks > 0)
                        {
                            return new Duration(TimeUnit.Quarters, quartersFromWeeks) +
                                   new Duration(TimeUnit.Weeks, remainderWeeks);
                        }

                        return new Duration(TimeUnit.Quarters, quartersFromWeeks);
                    case TimeUnit.Months:
                        endDate = date.Value.AddMonths(Units);
                        var quartersFromMonths = (endDate.Year - date.Value.Year) * 4 +
                                                 (endDate.Month - date.Value.Month) / 3;

                        var endOfQuarter = date.Value.AddMonths(quartersFromMonths * 3);
                        var remainderMonths = Duration.Days((endDate - endOfQuarter).TotalDays.ToInt())
                            .ConvertTo(TimeUnit.Months, endOfQuarter);


                        if ((endDate - endOfQuarter).TotalDays.ToInt() > 0)
                        {
                            return new Duration(TimeUnit.Quarters, quartersFromMonths) + remainderMonths;
                        }

                        return new Duration(TimeUnit.Quarters, quartersFromMonths);
                    case TimeUnit.Years:
                        return new Duration(TimeUnit.Quarters, Units * 4);
                    case TimeUnit.Quarters:
                        return new Duration(TimeUnit.Quarters, Units);
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    public static Duration Days(int days)
    {
        return new Duration(TimeUnit.Days, days);
    }

    public static Duration Days()
    {
        return new Duration(TimeUnit.Days, 1);
    }

    // Weeks
    public static Duration Weeks(int weeks)
    {
        return new Duration(TimeUnit.Weeks, weeks);
    }
    
    // Months
    public static Duration Months(int months)
    {
        return new Duration(TimeUnit.Months, months);
    }
    
    // Quarters
    public static Duration Quarters(int quarters)
    {
        return new Duration(TimeUnit.Quarters, quarters);
    }
    
    // Years
    public static Duration Years(int years)
    {
        return new Duration(TimeUnit.Years, years);
    }
    
    // Hours
    public static Duration Hours(int hours)
    {
        return new Duration(TimeUnit.Hours, hours);
    }

    public static Duration Hours()
    {
        return new Duration(TimeUnit.Hours, 1);
    }

    // equals
    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        if (obj.GetType() != GetType())
            return false;
        return Equals( this, ( Duration) obj);
    }
    
    public bool Equals(Duration x, Duration y)
    {
        if (x.OtherDurations.Count() != y.OtherDurations.Count())
            return false;
        if( x.OtherDurations.Any(x => !y.OtherDurations.Any(x.Equals)))
            return false;
        
        return x.Time == y.Time && x.Units == y.Units;
    } 
    
    public static bool operator ==(Duration left, Duration right)
    {
        return  left.Equals(right);
    }
    
    public static bool operator !=(Duration left, Duration right)
    {
        return !(left == right);
    }


}