using Abstractions;

namespace Domain;

/// <summary>
///     Alternative idea: partition the books at the time they are put in the basket.
///     Thus, the calculation at the end is much easier
/// </summary>
public class ShoppingCartBookSetBased : IShoppingCart
{
    private readonly IBookSetCalculator _bookSetCalculator;
    private readonly IBookSetFactory _bookSetFactory;
    private readonly List<IBookSet> _bookSets;

    public ShoppingCartBookSetBased(IBookSetCalculator bookSetCalculator, IBookSetFactory bookSetFactory)
    {
        _bookSetCalculator = bookSetCalculator;
        _bookSetFactory = bookSetFactory;
        _bookSets = new List<IBookSet> { _bookSetFactory.Create() };
    }

    public IReadOnlyCollection<IBook> Books => _bookSets.SelectMany(set => set.Books).ToList();

    public void AddBook(IBook book)
    {
        var bookSet = _bookSets.Last();

        if (bookSet.TryAddBook(book)) return;

        var anotherBookSet = _bookSetFactory.Create();
        _bookSets.Add(anotherBookSet);
        anotherBookSet.TryAddBook(book);
    }

    public decimal GetPrice()
    {
        return _bookSetCalculator.Calculate(_bookSets);
    }
}