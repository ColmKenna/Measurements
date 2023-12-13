namespace Measurements;

public enum TimeUnit
{
    Hours,
    Days,
    Weeks,
    Months,
    Quarters,
    Years
}

public class Area : IUnitOfMeasurement<Area, AreaUnit>
    {
        public AreaUnit AreaType { get; }
        public decimal Amount { get; private set; }
        public List<Area> OtherAreas { get; } = new();

        public Area(AreaUnit areaType, decimal amount)
        {
            AreaType = areaType;
            Amount = amount;
        }

        public Area Add(Area value)
        {
            if (value.OtherAreas.Any())
            {
                foreach (var otherArea in value.OtherAreas)
                {
                    Add(otherArea);
                }
            }

            if (value.AreaType == AreaType)
            {
                Amount += value.Amount;
                return this;
            }

            this.OtherAreas.Add(value);
            return this;
        }

        public static Area operator +(Area a, Area b)
        {
            var newArea = new Area(a.AreaType, a.Amount);
            var newArea2 = new Area(b.AreaType, b.Amount);
            return newArea.Add(newArea2);
        }

        public Area GetAs(AreaUnit conversionSpec)
        {
            Area newArea = (AreaType == conversionSpec) ? this : ConvertCurrent(conversionSpec);
            if (OtherAreas.Count == 0)
                return newArea;

            var runningTotal = newArea.Amount;
            foreach (var otherArea in OtherAreas)
            {
                runningTotal += otherArea.GetAs(conversionSpec).Amount;
            }

            return new Area(conversionSpec, runningTotal);
        }

        private Area ConvertCurrent(AreaUnit conversionSpec)
        {
            switch (this.AreaType)
            {
                case AreaUnit.SquareMillimeters:
                    switch (conversionSpec)
                    {
                        case AreaUnit.SquareCentimeters:
                            return new Area(conversionSpec, Amount / 100);
                        case AreaUnit.SquareMeters:
                            return new Area(conversionSpec, Amount / 1000000);
                        case AreaUnit.SquareKilometers:
                            return new Area(conversionSpec, Amount / 1000000000000);
                        case AreaUnit.SquareInches:
                            return new Area(conversionSpec, Amount / 645.16m);
                        case AreaUnit.SquareFeet:
                            return new Area(conversionSpec, Amount / 92903.04m);
                        case AreaUnit.SquareYards:
                            return new Area(conversionSpec, Amount / 836127.36m);
                        case AreaUnit.Acres:
                            return new Area(conversionSpec, Amount / 4046856422.4m);
                        case AreaUnit.SquareMiles:
                            return new Area(conversionSpec, Amount / 2589988110336m);
                        case AreaUnit.Hectares:
                            return new Area(conversionSpec, Amount / 10000000000);
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                case AreaUnit.SquareCentimeters:
                    switch (conversionSpec)
                    {
                        case AreaUnit.SquareMillimeters:
                            return new Area(conversionSpec, Amount * 100);
                        case AreaUnit.SquareMeters:
                            return new Area(conversionSpec, Amount / 10000);
                        case AreaUnit.SquareKilometers:
                            return new Area(conversionSpec, Amount / 10000000000);
                        case AreaUnit.SquareInches:
                            return new Area(conversionSpec, Amount / 6.4516m);
                        case AreaUnit.SquareFeet:
                            return new Area(conversionSpec, Amount / 929.0304m);
                        case AreaUnit.SquareYards:
                            return new Area(conversionSpec, Amount / 8361.2736m);
                        case AreaUnit.Acres:
                            return new Area(conversionSpec, Amount / 40468564.224m);
                        case AreaUnit.SquareMiles:
                            return new Area(conversionSpec, Amount / 2589988110.336m);
                        case AreaUnit.Hectares:
                            return new Area(conversionSpec, Amount / 100000000);
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                case AreaUnit.SquareMeters:
                    switch (conversionSpec)
                    {
                        case AreaUnit.SquareMillimeters:
                            return new Area(conversionSpec, Amount * 1000000);
                        case AreaUnit.SquareCentimeters:
                            return new Area(conversionSpec, Amount * 10000);
                        case AreaUnit.SquareKilometers:
                            return new Area(conversionSpec, Amount / 1000000);
                        case AreaUnit.SquareInches:
                            return new Area(conversionSpec, Amount * 1550.0031m);
                        case AreaUnit.SquareFeet:
                            return new Area(conversionSpec, Amount * 10.763910417m);
                        case AreaUnit.SquareYards:
                            return new Area(conversionSpec, Amount * 1.1959900463m);
                        case AreaUnit.Acres:
                            return new Area(conversionSpec, Amount / 4046.8564224m);
                        case AreaUnit.SquareMiles:
                            return new Area(conversionSpec, Amount / 2589988.110336m);
                        case AreaUnit.Hectares:
                            return new Area(conversionSpec, Amount / 10000);
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                case AreaUnit.SquareKilometers:
                    switch (conversionSpec)
                    {
                        case AreaUnit.SquareMillimeters:
                            return new Area(conversionSpec, Amount * 1000000000000);
                        case AreaUnit.SquareCentimeters:
                            return new Area(conversionSpec, Amount * 10000000000);
                        case AreaUnit.SquareMeters:
                            return new Area(conversionSpec, Amount * 1000000);
                        case AreaUnit.SquareInches:
                            return new Area(conversionSpec, Amount * 1550003100m);
                        case AreaUnit.SquareFeet:
                            return new Area(conversionSpec, Amount * 10763910.417m);
                        case AreaUnit.SquareYards:
                            return new Area(conversionSpec, Amount * 1195990.0463m);
                        case AreaUnit.Acres:
                            return new Area(conversionSpec, Amount * 247.10538147m);
                        case AreaUnit.SquareMiles:
                            return new Area(conversionSpec, Amount / 2.589988110336m);
                        case AreaUnit.Hectares:
                            return new Area(conversionSpec, Amount * 100);
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                case AreaUnit.SquareInches:
                    switch (conversionSpec)
                    {
                        case AreaUnit.SquareMillimeters:
                            return new Area(conversionSpec, Amount * 645.16m);
                        case AreaUnit.SquareCentimeters:
                            return new Area(conversionSpec, Amount * 6.4516m);
                        case AreaUnit.SquareMeters:
                            return new Area(conversionSpec, Amount / 1550.0031m);
                        case AreaUnit.SquareKilometers:
                            return new Area(conversionSpec, Amount / 1550003100m);
                        case AreaUnit.SquareFeet:
                            return new Area(conversionSpec, Amount / 144);
                        case AreaUnit.SquareYards:
                            return new Area(conversionSpec, Amount / 1296);
                        case AreaUnit.Acres:
                            return new Area(conversionSpec, Amount / 6272640);
                        case AreaUnit.SquareMiles:
                            return new Area(conversionSpec, Amount / 4014489600);
                        case AreaUnit.Hectares:
                            return new Area(conversionSpec, Amount / 15500031);
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                case AreaUnit.SquareFeet:
                    switch (conversionSpec)
                    {
                        case AreaUnit.SquareMillimeters:
                            return new Area(conversionSpec, Amount * 92903.04m);
                        case AreaUnit.SquareCentimeters:
                            return new Area(conversionSpec, Amount * 929.0304m);
                        case AreaUnit.SquareMeters:
                            return new Area(conversionSpec, Amount / 10.763910417m);
                        case AreaUnit.SquareKilometers:
                            return new Area(conversionSpec, Amount / 10763910.417m);
                        case AreaUnit.SquareInches:
                            return new Area(conversionSpec, Amount * 144);
                        case AreaUnit.SquareYards:
                            return new Area(conversionSpec, Amount / 9);
                        case AreaUnit.Acres:
                            return new Area(conversionSpec, Amount / 43560);
                        case AreaUnit.SquareMiles:
                            return new Area(conversionSpec, Amount / 27878400);
                        case AreaUnit.Hectares:
                            return new Area(conversionSpec, Amount / 107639);
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                case AreaUnit.SquareYards:
                    switch (conversionSpec)
                    {
                        case AreaUnit.SquareMillimeters:
                            return new Area(conversionSpec, Amount * 836127.36m);
                        case AreaUnit.SquareCentimeters:
                            return new Area(conversionSpec, Amount * 8361.2736m);
                        case AreaUnit.SquareMeters:
                            return new Area(conversionSpec, Amount / 1.1959900463m);
                        case AreaUnit.SquareKilometers:
                            return new Area(conversionSpec, Amount / 1195990.0463m);
                        case AreaUnit.SquareInches:
                            return new Area(conversionSpec, Amount * 1296);
                        case AreaUnit.SquareFeet:
                            return new Area(conversionSpec, Amount * 9);
                        case AreaUnit.Acres:
                            return new Area(conversionSpec, Amount / 4840);
                        case AreaUnit.SquareMiles:
                            return new Area(conversionSpec, Amount / 3097600);
                        case AreaUnit.Hectares:
                            return new Area(conversionSpec, Amount / 11959.9m);
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                case AreaUnit.Acres:
                    switch (conversionSpec)
                    {
                        case AreaUnit.SquareMillimeters:
                            return new Area(conversionSpec, Amount * 4046856422.4m);
                        case AreaUnit.SquareCentimeters:
                            return new Area(conversionSpec, Amount * 40468564.224m);
                        case AreaUnit.SquareMeters:
                            return new Area(conversionSpec, Amount * 4046.8564224m);
                        case AreaUnit.SquareKilometers:
                            return new Area(conversionSpec, Amount / 247.10538147m);
                        case AreaUnit.SquareInches:
                            return new Area(conversionSpec, Amount * 6272640);
                        case AreaUnit.SquareFeet:
                            return new Area(conversionSpec, Amount * 43560);
                        case AreaUnit.SquareYards:
                            return new Area(conversionSpec, Amount * 4840);
                        case AreaUnit.SquareMiles:
                            return new Area(conversionSpec, Amount / 640);
                        case AreaUnit.Hectares:
                            return new Area(conversionSpec, Amount * 0.4046856424m);
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                case AreaUnit.SquareMiles:
                    switch (conversionSpec)
                    {
                        case AreaUnit.SquareMillimeters:
                            return new Area(conversionSpec, Amount * 2589988110336m);
                        case AreaUnit.SquareCentimeters:
                            return new Area(conversionSpec, Amount * 25899881103.36m);
                        case AreaUnit.SquareMeters:
                            return new Area(conversionSpec, Amount * 2589988.110336m);
                        case AreaUnit.SquareKilometers:
                            return new Area(conversionSpec, Amount * 2.589988110336m);
                        case AreaUnit.SquareInches:
                            return new Area(conversionSpec, Amount * 4014489600);
                        case AreaUnit.SquareFeet:
                            return new Area(conversionSpec, Amount * 27878400);
                        case AreaUnit.SquareYards:
                            return new Area(conversionSpec, Amount * 3097599.999598m);
                        case AreaUnit.Acres:
                            return new Area(conversionSpec, Amount * 640);
                        case AreaUnit.Hectares:
                            return new Area(conversionSpec, Amount * 258.9988110336m);
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                case AreaUnit.Hectares:
                    switch (conversionSpec)
                    {
                        case AreaUnit.SquareMillimeters:
                            return new Area(conversionSpec, Amount * 10000000000);
                        case AreaUnit.SquareCentimeters:
                            return new Area(conversionSpec, Amount * 100000000);
                        case AreaUnit.SquareMeters:
                            return new Area(conversionSpec, Amount * 10000);
                        case AreaUnit.SquareKilometers:
                            return new Area(conversionSpec, Amount / 100);
                        case AreaUnit.SquareInches:
                            return new Area(conversionSpec, Amount * 15500031);
                        case AreaUnit.SquareFeet:
                            return new Area(conversionSpec, Amount * 107639);
                        case AreaUnit.SquareYards:
                            return new Area(conversionSpec, Amount * 11959.9m);
                        case AreaUnit.Acres:
                            return new Area(conversionSpec, Amount / 0.4046856424m);
                        case AreaUnit.SquareMiles:
                            return new Area(conversionSpec, Amount / 258.9988110336m);
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static Area SquareMillimeters(decimal amount)
        {
            return new Area(AreaUnit.SquareMillimeters, amount);
        }

        public static Area SquareCentimeters(decimal amount)
        {
            return new Area(AreaUnit.SquareCentimeters, amount);
        }

        public static Area SquareMeters(decimal amount)
        {
            return new Area(AreaUnit.SquareMeters, amount);
        }

        public static Area SquareKilometers(decimal amount)
        {
            return new Area(AreaUnit.SquareKilometers, amount);
        }

        public static Area SquareInches(decimal amount)
        {
            return new Area(AreaUnit.SquareInches, amount);
        }

        public static Area SquareFeet(decimal amount)
        {
            return new Area(AreaUnit.SquareFeet, amount);
        }

        public static Area SquareYards(decimal amount)
        {
            return new Area(AreaUnit.SquareYards, amount);
        }

        public static Area Acres(decimal amount)
        {
            return new Area(AreaUnit.Acres, amount);
        }

        public static Area SquareMiles(decimal amount)
        {
            return new Area(AreaUnit.SquareMiles, amount);
        }
        
    }
    
    
    