using Abstractions;

namespace Domain;

public class BookSet : IBookSet
{
    private IBookSetCalculator _bookSetCalculator;

    public BookSet(IBookSetCalculator bookSetCalculator, params IBook[] books)
    {
        _bookSetCalculator = bookSetCalculator;
        Books = books;
    }

    public IBook[] Books { get; }

    public decimal GetPrice()
    {
        return _bookSetCalculator.Calculate(Books);
    }
}