namespace Abstractions;

public interface IBookSet
{
    IBook[] Books { get; }
    decimal GetPrice();
}