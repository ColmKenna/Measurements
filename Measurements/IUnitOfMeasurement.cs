namespace Measurements;

public interface IUnitOfMeasurement
{
}
public interface IUnitOfMeasurement<T, U> : IUnitOfMeasurement
{
    public T Add(T value);
    public T GetAs(U conversionSpec);
}




