namespace Measurements;

public enum VolumeUnit
{
    Milliliters,
    Liters,
    CubicMeters,
    CubicCentimeters,
    CubicInches,
    CubicFeet,
    CubicYards,
    Gallons,
    Quarts,
    USPints,
    UKPints,
    FluidOunces
}

public class Volume : IUnitOfMeasurement<Volume, VolumeUnit>
{

    public IList<Volume> OtherVolumes { get; set; } = new List<Volume>();

    public Volume(VolumeUnit volumeType, decimal amount)
    {
        VolumeType = volumeType;
        Amount = amount;
    }

    public VolumeUnit VolumeType { get; }
    public decimal Amount { get; private set; }

    public Volume Add(Volume value)
    {
        if (value.OtherVolumes.Any())
        {
            foreach (var sub in value.OtherVolumes)
            {
                this.Add(sub);
            }
        }

        if (value.VolumeType == this.VolumeType)
            Amount += value.Amount;

        this.OtherVolumes.Add(value);
        return this;
    }

    public Volume GetAs(VolumeUnit conversionSpec)
    {
        Volume newVolume = (VolumeType == conversionSpec) ? this : ConvertCurrent(conversionSpec);
        if (OtherVolumes.Count == 0)
            return newVolume;

        var runningTotal = newVolume.Amount;
        foreach (var otherVolume in OtherVolumes)
        {
            runningTotal += otherVolume.GetAs(conversionSpec).Amount;
        }

        return new Volume(conversionSpec, runningTotal);
    }

    public Volume ConvertCurrent(VolumeUnit newUnit)
    {
        switch (this.VolumeType)
        {
            case VolumeUnit.Milliliters:
                switch (newUnit)
                {
                    case VolumeUnit.Liters:
                        return new Volume(newUnit, Amount / 1000.0m);
                    case VolumeUnit.CubicMeters:
                        return new Volume(newUnit, Amount / 1000000.0m);
                    case VolumeUnit.CubicCentimeters:
                        return new Volume(newUnit, Amount);
                    case VolumeUnit.CubicInches:
                        return new Volume(newUnit, Amount * 0.0610237440947323m);
                    case VolumeUnit.CubicFeet:
                        return new Volume(newUnit, Amount * 0.0000353154868024998m);
                    case VolumeUnit.Gallons:
                        return new Volume(newUnit, Amount * 0.000264172052358148m);
                    case VolumeUnit.Quarts:
                        return new Volume(newUnit, Amount * 0.00105668820943259m);
                    case VolumeUnit.USPints:
                        return new Volume(newUnit, Amount * 0.00211337641886519m);
                    case VolumeUnit.FluidOunces:
                        return new Volume(newUnit, Amount * 0.033814022701843m);
                    case VolumeUnit.CubicYards:
                        return new Volume(newUnit, Amount * 0.00000130795061931439m);
                    case VolumeUnit.UKPints:
                        return new Volume(newUnit, Amount * 0.0017597539863927m);
                    case VolumeUnit.Milliliters:
                        return this;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(newUnit), newUnit, null);
                }
            case VolumeUnit.Liters:
                switch (newUnit)
                {
                    case VolumeUnit.Milliliters:
                        return new Volume(newUnit, Amount * 1000.0m);
                    case VolumeUnit.CubicMeters:
                        return new Volume(newUnit, Amount / 1000.0m);
                    case VolumeUnit.CubicCentimeters:
                        return new Volume(newUnit, Amount * 1000.0m);
                    case VolumeUnit.CubicInches:
                        return new Volume(newUnit, Amount * 61.0237440947323m);
                    case VolumeUnit.CubicFeet:
                        return new Volume(newUnit, Amount * 0.035314666721489m);
                    case VolumeUnit.Gallons:
                        return new Volume(newUnit, Amount * 0.264172052358148m);
                    case VolumeUnit.Quarts:
                        return new Volume(newUnit, Amount * 1.05668820943259m);
                    case VolumeUnit.USPints:
                        return new Volume(newUnit, Amount * 2.11337641886519m);
                    case VolumeUnit.FluidOunces:
                        return new Volume(newUnit, Amount * 33.814022701843m);
                    case VolumeUnit.CubicYards:
                        return new Volume(newUnit, Amount * 0.00130795061931439m);
                    case VolumeUnit.UKPints:
                        return new Volume(newUnit, Amount * 1.7597539863927023616m);
                    case VolumeUnit.Liters:
                        return this;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(newUnit), newUnit, null);
                }
            case VolumeUnit.CubicMeters:
                switch (newUnit)
                {
                    case VolumeUnit.Milliliters:
                        return new Volume(newUnit, Amount * 1000000.0m);
                    case VolumeUnit.Liters:
                        return new Volume(newUnit, Amount * 1000.0m);
                    case VolumeUnit.CubicCentimeters:
                        return new Volume(newUnit, Amount * 1000000.0m);
                    case VolumeUnit.CubicInches:
                        return new Volume(newUnit, Amount * 61023.744094732288000m);
                    case VolumeUnit.CubicFeet:
                        return new Volume(newUnit, Amount * 35.31466672148859m);
                    case VolumeUnit.Gallons:
                        return new Volume(newUnit, Amount * 264.1720523581m);
                    case VolumeUnit.Quarts:
                        return new Volume(newUnit, Amount * 1056.688209432593664m);
                    case VolumeUnit.USPints:
                        return new Volume(newUnit, Amount * 2113.376418865187109m);
                    case VolumeUnit.FluidOunces:
                        return new Volume(newUnit, Amount * 33814m);
                    case VolumeUnit.CubicYards:
                        return new Volume(newUnit, Amount * 1.30795061931439225m);
                    case VolumeUnit.UKPints:
                        return new Volume(newUnit, Amount * 1759.7539863927023616m);
                    case VolumeUnit.CubicMeters:
                        return this;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(newUnit), newUnit, null);
                }
            case VolumeUnit.CubicCentimeters:
                switch (newUnit)
                {
                    case VolumeUnit.Milliliters:
                        return new Volume(newUnit, Amount);
                    case VolumeUnit.Liters:
                        return new Volume(newUnit, Amount / 1000m);
                    case VolumeUnit.CubicMeters:
                        return new Volume(newUnit, Amount / 1000000m);
                    case VolumeUnit.CubicInches:
                        return new Volume(newUnit, Amount * 0.061023744094732288m);
                    case VolumeUnit.CubicFeet:
                        return new Volume(newUnit, Amount * 0.0000353147m);
                    case VolumeUnit.Gallons:
                        return new Volume(newUnit, Amount * 0.000264172m);
                    case VolumeUnit.Quarts:
                        return new Volume(newUnit, Amount * 0.001057m);
                    case VolumeUnit.USPints:
                        return new Volume(newUnit, Amount * 0.00211338m);
                    case VolumeUnit.FluidOunces:
                        return new Volume(newUnit, Amount * 0.033814m);
                    case VolumeUnit.CubicYards:
                        return new Volume(newUnit, Amount * 0.000001308m);
                    case VolumeUnit.UKPints:
                        return new Volume(newUnit, Amount * 0.00175975m);
                    case VolumeUnit.CubicCentimeters:
                        return this;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(newUnit), newUnit, null);
                }
            case VolumeUnit.CubicInches:
                switch (newUnit)
                {
                    case VolumeUnit.Milliliters:
                        return new Volume(newUnit, Amount * 16.387064m);
                    case VolumeUnit.Liters:
                        return new Volume(newUnit, Amount * 0.016387064m);
                    case VolumeUnit.CubicMeters:
                        return new Volume(newUnit, Amount * 0.000016387064m);
                    case VolumeUnit.CubicCentimeters:
                        return new Volume(newUnit, Amount * 16.387064m);
                    case VolumeUnit.CubicFeet:
                        return new Volume(newUnit, Amount * 0.000578703704m);
                    case VolumeUnit.Gallons:
                        return new Volume(newUnit, Amount * 0.004329004329m);
                    case VolumeUnit.Quarts:
                        return new Volume(newUnit, Amount * 0.017316017316m);
                    case VolumeUnit.USPints:
                        return new Volume(newUnit, Amount * 0.034632034632m);
                    case VolumeUnit.FluidOunces:
                        return new Volume(newUnit, Amount * 0.554112554113m);
                    case VolumeUnit.CubicYards:
                        return new Volume(newUnit, Amount * 0.0000214334705075m);
                    case VolumeUnit.UKPints:
                        return new Volume(newUnit, Amount * 0.028837201199272341504m);
                    case VolumeUnit.CubicInches:
                        return this;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(newUnit), newUnit, null);
                }
            case VolumeUnit.CubicFeet:
                switch (newUnit)
                {
                    case VolumeUnit.Milliliters:
                        return new Volume(newUnit, Amount * 28316.846592m);
                    case VolumeUnit.Liters:
                        return new Volume(newUnit, Amount * 28.316846592m);
                    case VolumeUnit.CubicMeters:
                        return new Volume(newUnit, Amount * 0.028316846592m);
                    case VolumeUnit.CubicCentimeters:
                        return new Volume(newUnit, Amount * 28316.846592m);
                    case VolumeUnit.CubicInches:
                        return new Volume(newUnit, Amount * 1728.0m);
                    case VolumeUnit.Gallons:
                        return new Volume(newUnit, Amount * 7.48051948051948m);
                    case VolumeUnit.Quarts:
                        return new Volume(newUnit, Amount * 29.922077922077920m);
                    case VolumeUnit.USPints:
                        return new Volume(newUnit, Amount * 59.844155844155842560m);
                    case VolumeUnit.FluidOunces:
                        return new Volume(newUnit, Amount * 957.506493506494m);
                    case VolumeUnit.CubicYards:
                        return new Volume(newUnit, Amount * 0.037037037037037m);
                    case VolumeUnit.UKPints:
                        return new Volume(newUnit, Amount * 49.8307m);
                    case VolumeUnit.CubicFeet:
                        return this;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(newUnit), newUnit, null);
                }
            case VolumeUnit.Gallons:
                switch (newUnit)
                {
                    case VolumeUnit.Milliliters:
                        return new Volume(newUnit, Amount * 3785.41m);
                    case VolumeUnit.Liters:
                        return new Volume(newUnit, Amount * 3.78541m);
                    case VolumeUnit.CubicMeters:
                        return new Volume(newUnit, Amount * 0.00378541m);
                    case VolumeUnit.CubicCentimeters:
                        return new Volume(newUnit, Amount * 3785.41m);
                    case VolumeUnit.CubicInches:
                        return new Volume(newUnit, Amount * 231m);
                    case VolumeUnit.CubicFeet:
                        return new Volume(newUnit, Amount * 0.133681m);
                    case VolumeUnit.Quarts:
                        return new Volume(newUnit, Amount * 4m);
                    case VolumeUnit.USPints:
                        return new Volume(newUnit, Amount * 8m);
                    case VolumeUnit.FluidOunces:
                        return new Volume(newUnit, Amount * 128m);
                    case VolumeUnit.CubicYards:
                        return new Volume(newUnit, Amount * 0.00495113m);
                    case VolumeUnit.UKPints:
                        return new Volume(newUnit, Amount * 6.66139m);
                    case VolumeUnit.Gallons:
                        return this;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(newUnit), newUnit, null);
                }
            case VolumeUnit.Quarts:
                switch (newUnit)
                {
                    case VolumeUnit.Milliliters:
                        return new Volume(newUnit, Amount * 946.353m);
                    case VolumeUnit.Liters:
                        return new Volume(newUnit, Amount * 0.946352946m);
                    case VolumeUnit.CubicMeters:
                        return new Volume(newUnit, Amount * 0.000946353m);
                    case VolumeUnit.CubicCentimeters:
                        return new Volume(newUnit, Amount * 946.353m);
                    case VolumeUnit.CubicInches:
                        return new Volume(newUnit, Amount * 57.75m);
                    case VolumeUnit.CubicFeet:
                        return new Volume(newUnit, Amount * 0.0334201m);
                    case VolumeUnit.Gallons:
                        return new Volume(newUnit, Amount * 0.25m);
                    case VolumeUnit.USPints:
                        return new Volume(newUnit, Amount * 2m);
                    case VolumeUnit.FluidOunces:
                        return new Volume(newUnit, Amount * 32m);
                    case VolumeUnit.CubicYards:
                        return new Volume(newUnit, Amount / 807.9m);
                    case VolumeUnit.UKPints:
                        return new Volume(newUnit, Amount * 1.66535m);
                    case VolumeUnit.Quarts:
                        return this;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(newUnit), newUnit, null);
                }
            case VolumeUnit.USPints:
                   switch (newUnit)
                    {
                        case VolumeUnit.Milliliters:
                            return new Volume(newUnit, Amount * 473.176473m);
                        case VolumeUnit.Liters:
                            return new Volume(newUnit, Amount * 0.473176473m);
                        case VolumeUnit.CubicMeters:
                            return new Volume(newUnit, Amount * 0.000473176473m);
                        case VolumeUnit.CubicCentimeters:
                            return new Volume(newUnit, Amount * 473.176473m);
                        case VolumeUnit.CubicInches:
                            return new Volume(newUnit, Amount * 28.875m);
                        case VolumeUnit.CubicFeet:
                            return new Volume(newUnit, Amount * 0.0167100694444444m);
                        case VolumeUnit.Gallons:
                            return new Volume(newUnit, Amount * 0.125m);
                        case VolumeUnit.Quarts:
                            return new Volume(newUnit, Amount * 0.5m);
                        case VolumeUnit.FluidOunces:
                            return new Volume(newUnit, Amount * 16.0m);
                        case VolumeUnit.CubicYards:
                            return new Volume(newUnit, Amount * 0.00061889146090534976563m);
                        case VolumeUnit.UKPints:
                            return new Volume(newUnit, Amount * 0.832674184604601m);
                        case VolumeUnit.USPints:
                            return this;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(newUnit), newUnit, null);
                    }
            case VolumeUnit.FluidOunces:
                switch (newUnit)
                {
                    case VolumeUnit.Milliliters:
                        return new Volume(newUnit, Amount * 29.5735295625m);
                    case VolumeUnit.Liters:
                        return new Volume(newUnit, Amount * 0.0295735295625m);
                    case VolumeUnit.CubicMeters:
                        return new Volume(newUnit, Amount * 0.0000295735295625m);
                    case VolumeUnit.CubicCentimeters:
                        return new Volume(newUnit, Amount * 29.5735295625m);
                    case VolumeUnit.CubicInches:
                        return new Volume(newUnit, Amount * 1.8046875m);
                    case VolumeUnit.CubicFeet:
                        return new Volume(newUnit, Amount * 0.00104437934027778m);
                    case VolumeUnit.Gallons:
                        return new Volume(newUnit, Amount * 0.0078125m);
                    case VolumeUnit.Quarts:
                        return new Volume(newUnit, Amount * 0.03125m);
                    case VolumeUnit.USPints:
                        return new Volume(newUnit, Amount * 0.0625m);
                    case VolumeUnit.CubicYards:
                        return new Volume(newUnit, Amount / 25850m);
                    case VolumeUnit.UKPints:
                        return new Volume(newUnit, Amount * 0.052042126456m);
                    case VolumeUnit.FluidOunces:
                        return this;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(newUnit), newUnit, null);
                }
            case VolumeUnit.CubicYards:
                switch (newUnit)
                {
                    case VolumeUnit.Milliliters:
                        return new Volume(newUnit, Amount * 764554.858m);
                    case VolumeUnit.Liters:
                        return new Volume(newUnit, Amount * 764.554858m);
                    case VolumeUnit.CubicMeters:
                        return new Volume(newUnit, Amount * 0.764554857984m);
                    case VolumeUnit.CubicCentimeters:
                        return new Volume(newUnit, Amount * 764554.858m);
                    case VolumeUnit.CubicInches:
                        return new Volume(newUnit, Amount * 46656m);
                    case VolumeUnit.CubicFeet:
                        return new Volume(newUnit, Amount * 27m);
                    case VolumeUnit.Gallons:
                        return new Volume(newUnit, Amount * 201.974026m);
                    case VolumeUnit.Quarts:
                        return new Volume(newUnit, Amount * 807.89610389615m);
                    case VolumeUnit.USPints:
                        return new Volume(newUnit, Amount * 1615.792233m);
                    case VolumeUnit.FluidOunces:
                        return new Volume(newUnit, Amount * 25852.7m);
                    case VolumeUnit.UKPints:
                        return new Volume(newUnit, Amount * 1345.43m);
                    case VolumeUnit.CubicYards:
                        return this;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(newUnit), newUnit, null);
                }
            case VolumeUnit.UKPints:
                switch (newUnit)
                {
                    case VolumeUnit.Milliliters:
                        return new Volume(newUnit, Amount * 568.26125m);
                    case VolumeUnit.Liters:
                        return new Volume(newUnit, Amount * 0.5682612500m);
                    case VolumeUnit.CubicMeters:
                        return new Volume(newUnit, Amount * 0.00056826125m);
                    case VolumeUnit.CubicCentimeters:
                        return new Volume(newUnit, Amount * 568.26125m);
                    case VolumeUnit.CubicInches:
                        return new Volume(newUnit, Amount * 34.677429098955308007m);
                    case VolumeUnit.CubicFeet:
                        return new Volume(newUnit, Amount * 0.020067957m);
                    case VolumeUnit.Gallons:
                        return new Volume(newUnit, Amount * 0.15011874068810686m);
                    case VolumeUnit.Quarts:
                        return new Volume(newUnit, Amount * 0.60047496275242742m);
                    case VolumeUnit.USPints:
                        return new Volume(newUnit, Amount * 1.2009499255048548m);
                    case VolumeUnit.FluidOunces:
                        return new Volume(newUnit, Amount * 19.215198m);
                    case VolumeUnit.CubicYards:
                        return new Volume(newUnit, Amount / 1345m);
                    case VolumeUnit.UKPints:
                        return this;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(newUnit), newUnit, null);
                    
        }
       }
        throw new ArgumentOutOfRangeException();
    }
    
    public static Volume Milliliters(decimal amount) => new Volume(VolumeUnit.Milliliters, amount);
    public static Volume Liters(decimal amount) => new Volume(VolumeUnit.Liters, amount);
    public static Volume CubicMeters(decimal amount) => new Volume(VolumeUnit.CubicMeters, amount);
    public static Volume CubicCentimeters(decimal amount) => new Volume(VolumeUnit.CubicCentimeters, amount);
    public static Volume CubicInches(decimal amount) => new Volume(VolumeUnit.CubicInches, amount);
    public static Volume CubicFeet(decimal amount) => new Volume(VolumeUnit.CubicFeet, amount);
    public static Volume CubicYards(decimal amount) => new Volume(VolumeUnit.CubicYards, amount);
    public static Volume Gallons(decimal amount) => new Volume(VolumeUnit.Gallons, amount);
    public static Volume Quarts(decimal amount) => new Volume(VolumeUnit.Quarts, amount);
    public static Volume USPints(decimal amount) => new Volume(VolumeUnit.USPints, amount);
    public static Volume UKPints(decimal amount) => new Volume(VolumeUnit.UKPints, amount);
    public static Volume FluidOunces(decimal amount) => new Volume(VolumeUnit.FluidOunces, amount);
    
}
    