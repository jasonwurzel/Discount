namespace Abstractions;

public interface IBookSetCalculator
{
    decimal Calculate(IBook[] books);
}