using Abstractions;
using Domain;

namespace Logic;

public class BookSetCalculator : IBookSetCalculator
{
    private readonly decimal[] _discounts = { 0, 0.05m, 0.10m, 0.20m, 0.25m };

    public decimal Calculate(List<IBook> books)
    {
        var bookSets = partitionBooks(books);

        var result = Calculate(bookSets);

        return result;
    }

    public decimal Calculate(List<IBookSet> bookSets)
    {
        return bookSets.Sum(set => set.GetPrice());
    }

    public decimal Calculate(IBookSet bookSet)
    {
        var booksCount = bookSet.Books.Count;
        if (booksCount > _discounts.Length) throw new ArgumentException("There are more distinct books in a set than discounts defined, please update either the BookTitle enum or the discounts definition");

        return booksCount * (1 - _discounts[booksCount - 1]) * GlobalValues.BookPriceDefault;
    }

    private List<IBookSet> partitionBooks(List<IBook> books)
    {
        // TODO: fitting problem at the end is not yet solved. I.e. it is not always best to find the largest fitting set if a rest remains
        // (e.g. having a set of 5 and 3 is worse discount than having a set of 4 and 4 (if input set is 2-2-2-1-1 )
        var booksGroupedByTitle = books.GroupBy(book => book.Title).Select(grouping => new Stack<IBook>(grouping)).ToList();
        var bookSets = new List<IBookSet>();

        while (true)
        {
            var set = new BookSet(this);

            foreach (var bookGroup in booksGroupedByTitle)
            {
                if (!bookGroup.TryPop(out var book))
                    continue;

                set.AddBook(book);
            }

            if (set.IsEmpty)
                break;

            bookSets.Add(set);
        }

        return bookSets;
    }
}