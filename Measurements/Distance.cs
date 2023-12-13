namespace Measurements;


public class Distance : IUnitOfMeasurement<Distance, DistanceUnit>
{
    public DistanceUnit DistanceType { get; }
    public decimal Amount { get; private set; }
    public List<Distance> OtherDistances { get; } = new List<Distance>();

    public Distance(DistanceUnit distanceType, decimal amount)
    {
        DistanceType = distanceType;
        Amount = amount;
    }

    public Distance Add(Distance value)
    {
        
        if (value.OtherDistances.Count > 0)
        {
            foreach (var otherDistance in value.OtherDistances)
            {
                Add(otherDistance);
            }
        }
        
        if (DistanceType == value.DistanceType)
        {
            Amount += value.Amount;
            return this;
        }
        OtherDistances.Add(value);
        return this;
    }

    public Distance GetAs(DistanceUnit conversionSpec)
    {
        var newDistance = (DistanceType == conversionSpec) ? this : ConvertCurrent(conversionSpec);
        if (OtherDistances.Count == 0)
            return newDistance;
        
        var runningTotal = newDistance.Amount;
        foreach (var otherDistance in OtherDistances)
        {
            runningTotal += otherDistance.GetAs(conversionSpec).Amount;
        }
        
        return new Distance(conversionSpec, runningTotal);
    }

    private Distance ConvertCurrent(DistanceUnit conversionSpec)
    {
        switch (DistanceType)
        {
            case DistanceUnit.Millimeters:
                switch (conversionSpec)
                {
                    case DistanceUnit.Centimeters:
                        return new Distance(DistanceUnit.Centimeters, Amount / 10m);
                    case DistanceUnit.Meters:
                        return new Distance(DistanceUnit.Meters, Amount / 1000m);
                    case DistanceUnit.Kilometers:
                        return new Distance(DistanceUnit.Kilometers, Amount / 1000000m);
                    case DistanceUnit.Inches:
                        return new Distance(DistanceUnit.Inches, Amount / 25.4m);
                    case DistanceUnit.Feet:
                        return new Distance(DistanceUnit.Feet, Amount / 304.8m);
                    case DistanceUnit.Yards:
                        return new Distance(DistanceUnit.Yards, Amount / 914.4m);
                    case DistanceUnit.Miles:
                        return new Distance(DistanceUnit.Miles, Amount / 1609344m);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case DistanceUnit.Centimeters:
                switch (conversionSpec)
                {
                    case DistanceUnit.Millimeters:
                        return new Distance(DistanceUnit.Millimeters, Amount * 10m);
                    case DistanceUnit.Meters:
                        return new Distance(DistanceUnit.Meters, Amount / 100m);
                    case DistanceUnit.Kilometers:
                        return new Distance(DistanceUnit.Kilometers, Amount / 100000m);
                    case DistanceUnit.Inches:
                        return new Distance(DistanceUnit.Inches, Amount / 2.54m);
                    case DistanceUnit.Feet:
                        return new Distance(DistanceUnit.Feet, Amount / 30.48m);
                    case DistanceUnit.Yards:
                        return new Distance(DistanceUnit.Yards, Amount / 91.44m);
                    case DistanceUnit.Miles:
                        return new Distance(DistanceUnit.Miles, Amount / 160934m);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case DistanceUnit.Meters:
                switch (conversionSpec)
                {
                    case DistanceUnit.Millimeters:
                        return new Distance(DistanceUnit.Millimeters, Amount * 1000m);
                    case DistanceUnit.Centimeters:
                        return new Distance(DistanceUnit.Centimeters, Amount * 100m);
                    case DistanceUnit.Kilometers:
                        return new Distance(DistanceUnit.Kilometers, Amount / 1000m);
                    case DistanceUnit.Inches:
                        return new Distance(DistanceUnit.Inches, Amount * 39.3701m);
                    case DistanceUnit.Feet:
                        return new Distance(DistanceUnit.Feet, Amount * 3.28084m);
                    case DistanceUnit.Yards:
                        return new Distance(DistanceUnit.Yards, Amount * 1.09361m);
                    case DistanceUnit.Miles:
                        return new Distance(DistanceUnit.Miles, Amount / 1609.34m);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case DistanceUnit.Kilometers:
                switch (conversionSpec)
                {
                    case DistanceUnit.Millimeters:
                        return new Distance(DistanceUnit.Millimeters, Amount * 1000000m);
                    case DistanceUnit.Centimeters:
                        return new Distance(DistanceUnit.Centimeters, Amount * 100000m);
                    case DistanceUnit.Meters:
                        return new Distance(DistanceUnit.Meters, Amount * 1000m);
                    case DistanceUnit.Inches:
                        return new Distance(DistanceUnit.Inches, Amount * 39370.078740157m);
                    case DistanceUnit.Feet:
                        return new Distance(DistanceUnit.Feet, Amount * 3280.839895013083m);
                    case DistanceUnit.Yards:
                        return new Distance(DistanceUnit.Yards, Amount * 1093.61m);
                    case DistanceUnit.Miles:
                        return new Distance(DistanceUnit.Miles, Amount / 1.60934m);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case DistanceUnit.Inches:
                switch (conversionSpec)
                {
                    case DistanceUnit.Millimeters:
                        return new Distance(DistanceUnit.Millimeters, Amount * 25.4m);
                    case DistanceUnit.Centimeters:
                        return new Distance(DistanceUnit.Centimeters, Amount * 2.54m);
                    case DistanceUnit.Meters:
                        return new Distance(DistanceUnit.Meters, Amount / 39.3701m);
                    case DistanceUnit.Kilometers:
                        return new Distance(DistanceUnit.Kilometers, Amount / 39370.1m);
                    case DistanceUnit.Feet:
                        return new Distance(DistanceUnit.Feet, Amount / 12m);
                    case DistanceUnit.Yards:
                        return new Distance(DistanceUnit.Yards, Amount / 36m);
                    case DistanceUnit.Miles:
                        return new Distance(DistanceUnit.Miles, Amount / 63360m);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case DistanceUnit.Feet:
                switch (conversionSpec)
                {
                    case DistanceUnit.Millimeters:
                        return new Distance(DistanceUnit.Millimeters, Amount * 304.8m);
                    case DistanceUnit.Centimeters:
                        return new Distance(DistanceUnit.Centimeters, Amount * 30.48m);
                    case DistanceUnit.Meters:
                        return new Distance(DistanceUnit.Meters, Amount / 3.28084m);
                    case DistanceUnit.Kilometers:
                        return new Distance(DistanceUnit.Kilometers, Amount / 3280.84m);
                    case DistanceUnit.Inches:
                        return new Distance(DistanceUnit.Inches, Amount * 12m);
                    case DistanceUnit.Yards:
                        return new Distance(DistanceUnit.Yards, Amount / 3m);
                    case DistanceUnit.Miles:
                        return new Distance(DistanceUnit.Miles, Amount / 5280m);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case DistanceUnit.Yards:
                switch (conversionSpec)
                {
                    case DistanceUnit.Millimeters:
                        return new Distance(DistanceUnit.Millimeters, Amount * 914.4m);
                    case DistanceUnit.Centimeters:
                        return new Distance(DistanceUnit.Centimeters, Amount * 91.44m);
                    case DistanceUnit.Meters:
                        return new Distance(DistanceUnit.Meters, Amount / 1.09361m);
                    case DistanceUnit.Kilometers:
                        return new Distance(DistanceUnit.Kilometers, Amount / 1093.61m);
                    case DistanceUnit.Inches:
                        return new Distance(DistanceUnit.Inches, Amount * 36m);
                    case DistanceUnit.Feet:
                        return new Distance(DistanceUnit.Feet, Amount * 3m);
                    case DistanceUnit.Miles:
                        return new Distance(DistanceUnit.Miles, Amount / 1760m);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case DistanceUnit.Miles:
                switch (conversionSpec)
                {
                    case DistanceUnit.Millimeters:
                        return new Distance(DistanceUnit.Millimeters, Amount * 1609344m);
                    case DistanceUnit.Centimeters:
                        return new Distance(DistanceUnit.Centimeters, Amount * 160934.4m);
                    case DistanceUnit.Meters:
                        return new Distance(DistanceUnit.Meters, Amount * 1609.344m);
                    case DistanceUnit.Kilometers:
                        return new Distance(DistanceUnit.Kilometers, Amount * 1.609344m);
                    case DistanceUnit.Inches:
                        return new Distance(DistanceUnit.Inches, Amount * 63360m);
                    case DistanceUnit.Feet:
                        return new Distance(DistanceUnit.Feet, Amount * 5280m);
                    case DistanceUnit.Yards:
                        return new Distance(DistanceUnit.Yards, Amount * 1760m);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            default:
                throw new ArgumentOutOfRangeException();
        }
    }


    public static Distance Millimeters(int amount)
    {
        return new Distance(DistanceUnit.Millimeters, amount);
    }
    
    public static Distance Centimeters(int amount)
    {
        return new Distance(DistanceUnit.Centimeters, amount);
    }
    
    public static Distance Meters(int amount)
    {
        return new Distance(DistanceUnit.Meters, amount);
    }
    
    public static Distance Kilometers(int amount)
    {
        return new Distance(DistanceUnit.Kilometers, amount);
    }
    
    public static Distance Inches(int amount)
    {
        return new Distance(DistanceUnit.Inches, amount);
    }
    
    public static Distance Feet(int amount)
    {
        return new Distance(DistanceUnit.Feet, amount);
    }
    
    public static Distance Yards(int amount)
    {
        return new Distance(DistanceUnit.Yards, amount);
    }
    
    public static Distance Miles(int amount)
    {
        return new Distance(DistanceUnit.Miles, amount);
    }
    
    
    
}