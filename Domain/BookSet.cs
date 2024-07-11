using Abstractions;

namespace Domain;

public class BookSet : IBookSet
{
    private readonly IBookSetCalculator _bookSetCalculator;
    private readonly List<IBook> _books = new();

    public BookSet(IBookSetCalculator bookSetCalculator)
    {
        _bookSetCalculator = bookSetCalculator;
    }

    public IReadOnlyCollection<IBook> Books => _books;

    public bool IsFull => _books.Count == BookTitles.All.Length;

    public decimal GetPrice()
    {
        return _bookSetCalculator.Calculate(this);
    }

    public bool TryAddBook(IBook book)
    {
        if (_books.Any(b => b.Equals(book))) return false;

        _books.Add(book);
        return true;
    }
}