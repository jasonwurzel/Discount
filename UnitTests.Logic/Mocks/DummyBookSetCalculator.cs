using Abstractions;

namespace UnitTests.Logic.Mocks;

public class DummyBookSetCalculator : IBookSetCalculator
{
    public decimal Calculate(List<IBook> books)
    {
        return 0;
    }

    public decimal Calculate(List<IBookSet> bookSets)
    {
        return 0;
    }

    public decimal Calculate(IBookSet bookSet)
    {
        return 0;
    }
}