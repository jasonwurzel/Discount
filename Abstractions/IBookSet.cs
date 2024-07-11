namespace Abstractions;

public interface IBookSet
{
    IReadOnlyCollection<IBook> Books { get; }

    bool IsFull { get; }

    decimal GetPrice();
    
    bool TryAddBook(IBook book);
}