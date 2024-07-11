namespace Abstractions;

public interface IBookSetCalculator
{
    decimal Calculate(List<IBook> books);

    decimal Calculate(List<IBookSet> bookSets);

    decimal Calculate(IBookSet bookSet);
}