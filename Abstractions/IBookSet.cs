namespace Abstractions;

public interface IBookSet
{
    IReadOnlyCollection<IBook> Books { get; }
    bool IsFull { get; }

    bool IsOptimalSize { get; } 

    decimal GetPrice();
    
    bool TryAddBook(IBook book);
}