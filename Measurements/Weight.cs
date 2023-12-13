namespace Measurements;

public class Weight : IUnitOfMeasurement<Weight, WeightUnit>
{
    public Weight(WeightUnit weightType, decimal amount)
    {
        WeightType = weightType;
        Amount = amount;
        OtherWeights = new List<Weight>();
    }

    public WeightUnit WeightType { get; set; }
    public decimal Amount { get; set; }
    public IList<Weight> OtherWeights { get; set; }

    public Weight Add(Weight value)
    {
        if (value.OtherWeights.Count > 0)
        {
            foreach (var otherWeight in value.OtherWeights)
            {
                Add(otherWeight);
            }
        }
        
        if (WeightType == value.WeightType)
        {
            Amount += value.Amount;
            return this;
        }
        this.OtherWeights.Add(value);
        return this;
    }

    public Weight GetAs(WeightUnit conversionSpec)
    {
        Weight newWeight = (WeightType == conversionSpec)? this:  ConvertCurrent(conversionSpec);
        if(OtherWeights.Count == 0)
            return newWeight;

        var runningTotal = newWeight.Amount;
        foreach (var otherWeight in OtherWeights)
        {
            runningTotal += otherWeight.GetAs(conversionSpec).Amount;
        }
 
        return new Weight(conversionSpec, runningTotal);
            
    }

    private Weight ConvertCurrent(WeightUnit unit)
    {
        switch (WeightType)
        {
            case WeightUnit.Kilograms:
                switch (unit)
                {
                    case WeightUnit.Grams:
                        return new Weight(WeightUnit.Grams, Amount * 1000m);
                    case WeightUnit.Milligrams:
                        return new Weight(WeightUnit.Milligrams, Amount * 1000000m);
                    case WeightUnit.Pounds:
                        return new Weight(WeightUnit.Pounds, Amount * 2.2046226218487758848m);
                    case WeightUnit.Ounces:
                        return new Weight(WeightUnit.Ounces, Amount * 35.274m);
                    case WeightUnit.Stones:
                        return new Weight(WeightUnit.Stones, Amount * 0.157473m);
                    case WeightUnit.MetricTons:
                        return new Weight(WeightUnit.MetricTons, Amount / 1000m);
                    case WeightUnit.USTons:
                        return new Weight(WeightUnit.USTons, Amount / 907.185m);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case WeightUnit.Grams:
                switch (unit)
                {
                    case WeightUnit.Kilograms:
                        return new Weight(WeightUnit.Kilograms, Amount / 1000m);
                    case WeightUnit.Milligrams:
                        return new Weight(WeightUnit.Milligrams, Amount * 1000m);
                    case WeightUnit.Pounds:
                        return new Weight(WeightUnit.Pounds, Amount * 0.00220462m);
                    case WeightUnit.Ounces:
                        return new Weight(WeightUnit.Ounces, Amount * 0.035274m);
                    case WeightUnit.Stones:
                        return new Weight(WeightUnit.Stones, Amount * 0.000157473m);
                    case WeightUnit.MetricTons:
                        return new Weight(WeightUnit.MetricTons, Amount / 1_000_000m);
                    case WeightUnit.USTons:
                        return new Weight(WeightUnit.USTons, Amount / 907_185m);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case WeightUnit.Milligrams:
                switch (unit)
                {
                    case WeightUnit.Kilograms:
                        return new Weight(WeightUnit.Kilograms, Amount / 1000000m);
                    case WeightUnit.Grams:
                        return new Weight(WeightUnit.Grams, Amount / 1000m);
                    case WeightUnit.Pounds:
                        return new Weight(WeightUnit.Pounds, Amount * 0.00000220462m);
                    case WeightUnit.Ounces:
                        return new Weight(WeightUnit.Ounces, Amount * 0.000035274m);
                    case WeightUnit.Stones:
                        return new Weight(WeightUnit.Stones, Amount * 0.000000157473m);
                    case WeightUnit.MetricTons:
                        return new Weight(WeightUnit.MetricTons, Amount / 1_000_000_000m);
                    case WeightUnit.USTons:
                        return new Weight(WeightUnit.USTons, Amount / 907_185_000m);
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            case WeightUnit.Pounds:
                switch (unit)
                {
                    case WeightUnit.Kilograms:
                        return new Weight(WeightUnit.Kilograms, Amount * 0.45359237m);
                    case WeightUnit.Grams:
                        return new Weight(WeightUnit.Grams, Amount * 453.59237m);
                    case WeightUnit.Milligrams:
                        return new Weight(WeightUnit.Milligrams, Amount * 453592.37m);
                    case WeightUnit.Ounces:
                        return new Weight(WeightUnit.Ounces, Amount * 16m);
                    case WeightUnit.Stones:
                        return new Weight(WeightUnit.Stones, Amount / 14m);
                    case WeightUnit.MetricTons:
                        return new Weight(WeightUnit.MetricTons, Amount / 2204.62m);
                    case WeightUnit.USTons:
                        return new Weight(WeightUnit.USTons, Amount / 2000m);
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            case WeightUnit.Ounces:
                switch (unit)
                {
                    case WeightUnit.Kilograms:
                        return new Weight(WeightUnit.Kilograms, Amount / 35.274m);
                    case WeightUnit.Grams:
                        return new Weight(WeightUnit.Grams, Amount * 28.3495m);
                    case WeightUnit.Milligrams:
                        return new Weight(WeightUnit.Milligrams, Amount * 28349.5m);
                    case WeightUnit.Pounds:
                        return new Weight(WeightUnit.Pounds, Amount / 16m);
                    case WeightUnit.Stones:
                        return new Weight(WeightUnit.Stones, Amount * 0.00446429m);
                    case WeightUnit.MetricTons:
                        return new Weight(WeightUnit.MetricTons, Amount / 35274m);
                    case WeightUnit.USTons:
                        return new Weight(WeightUnit.USTons, Amount / 32000m);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case WeightUnit.Stones:
                switch (unit)
                {
                    case WeightUnit.Kilograms:
                        return new Weight(WeightUnit.Kilograms, Amount * 6.35029318m);
                    case WeightUnit.Grams:
                        return new Weight(WeightUnit.Grams, Amount * 6350.29318m);
                    case WeightUnit.Milligrams:
                        return new Weight(WeightUnit.Milligrams, Amount * 6350293.18m);
                    case WeightUnit.Pounds:
                        return new Weight(WeightUnit.Pounds, Amount * 14m);
                    case WeightUnit.Ounces:
                        return new Weight(WeightUnit.Ounces, Amount * 224m);
                    case WeightUnit.MetricTons:
                        return new Weight(WeightUnit.MetricTons, Amount / 157.473m);
                    case WeightUnit.USTons:
                        return new Weight(WeightUnit.USTons, Amount / 142.857m);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case WeightUnit.MetricTons:
                switch (unit)
                {
                    case WeightUnit.Kilograms:
                        return new Weight(WeightUnit.Kilograms, Amount * 1000m);
                    case WeightUnit.Grams:
                        return new Weight(WeightUnit.Grams, Amount * 1_000_000m);
                    case WeightUnit.Milligrams:
                        return new Weight(WeightUnit.Milligrams, Amount * 1_000_000_000m);
                    case WeightUnit.Pounds:
                        return new Weight(WeightUnit.Pounds, Amount * 2204.6226218487756m);
                    case WeightUnit.Ounces:
                        return new Weight(WeightUnit.Ounces, Amount * 35274m);
                    case WeightUnit.Stones:
                        return new Weight(WeightUnit.Stones, Amount * 157.4730444178m);
                    case WeightUnit.USTons:
                        return new Weight(WeightUnit.USTons, Amount * 1.10231m);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case WeightUnit.USTons:

                switch (unit)
                {
                    case WeightUnit.Kilograms:
                        return new Weight(WeightUnit.Kilograms, Amount * 907.185m);
                    case WeightUnit.Grams:
                        return new Weight(WeightUnit.Grams, Amount * 907185m);
                    case WeightUnit.Milligrams:
                        return new Weight(WeightUnit.Milligrams, Amount * 907185000m);
                    case WeightUnit.Pounds:
                        return new Weight(WeightUnit.Pounds, Amount * 2000m);
                    case WeightUnit.Ounces:
                        return new Weight(WeightUnit.Ounces, Amount * 32000m);
                    case WeightUnit.Stones:
                        return new Weight(WeightUnit.Stones, Amount * 142.85714285714284m);
                    case WeightUnit.MetricTons:
                        return new Weight(WeightUnit.MetricTons, Amount * 0.907185m);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            default:
                throw new ArgumentOutOfRangeException();
        }

        throw new ArgumentOutOfRangeException();

    }

    public static Weight Milligrams(decimal amount)
    {
        return new Weight(WeightUnit.Milligrams, amount);
    }
    
    public static Weight Grams(decimal amount)
    {
        return new Weight(WeightUnit.Grams, amount);
    }
    
    public static Weight Kilograms(decimal amount)
    {
        return new Weight(WeightUnit.Kilograms, amount);
    }
    
    public static Weight MetricTons(decimal amount)
    {
        return new Weight(WeightUnit.MetricTons, amount);
    }
    
    public static Weight USTons(decimal amount)
    {
        return new Weight(WeightUnit.USTons, amount);
    }
    
    public static Weight Ounces(decimal amount)
    {
        return new Weight(WeightUnit.Ounces, amount);
    }
    
    public static Weight Pounds(decimal amount)
    {
        return new Weight(WeightUnit.Pounds, amount);
    }
    
    public static Weight Stones(decimal amount)
    {
        return new Weight(WeightUnit.Stones, amount);
    }
    
    public static Weight operator +(Weight weight1, Weight weight2)
    {
        var result = new Weight(weight1.WeightType, weight1.Amount);
        return result.Add(weight2);
    }
    
}

 