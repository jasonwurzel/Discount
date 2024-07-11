using Abstractions;

namespace Domain;

/// <summary>
/// For later use: "ShoppingCart"
/// </summary>
public class ShoppingCart : IShoppingCart
{
    private readonly IBookSetCalculator _bookSetCalculator;
    private readonly List<IBook> _books = new();

    public ShoppingCart(IBookSetCalculator bookSetCalculator)
    {
        _bookSetCalculator = bookSetCalculator;
    }
    public void AddBook(IBook book)
    {
        _books.Add(book);
    }

    public decimal GetPrice()
    {
        return _bookSetCalculator.Calculate(_books);
    }
}