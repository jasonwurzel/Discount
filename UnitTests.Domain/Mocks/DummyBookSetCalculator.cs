using Abstractions;

namespace UnitTests.Domain.Mocks;

public class DummyBookSetCalculator : IBookSetCalculator
{
    private readonly decimal _fakePrice;

    public DummyBookSetCalculator(decimal fakePrice = 0m)
    {
        _fakePrice = fakePrice;
    }

    public decimal Calculate(List<IBook> books)
    {
        return _fakePrice;
    }

    public decimal Calculate(List<IBookSet> bookSets)
    {
        return _fakePrice;
    }

    public decimal Calculate(IBookSet bookSet)
    {
        return _fakePrice;
    }
}