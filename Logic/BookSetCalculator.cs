using Abstractions;
using Domain;

namespace Logic;

public class BookSetCalculator : IBookSetCalculator
{
    private readonly decimal[] _discounts = { 0, 0.05m, 0.10m, 0.20m, 0.25m };

    public decimal Calculate(List<IBook> books)
    {
        decimal result = 0m;

        /*
        idea for more real world implementation (e.g. working with the actual book instances instead of only instances for traceability (which book costs what, etc.)):
        instead of having int[] bookCountsByTitle = new int[5];
        use: List<List<IBook>> or similar and add the actual books instead of counting ++ and --
        thus we can later on create real "BookSet" instances
         */

        // count all books from all titles
        int[] bookCountsByTitle = new int[5];
        var allPossibleTitles = BookTitles.All;

        foreach (var book in books)
        {
            var indexOfBook = Array.IndexOf(allPossibleTitles, book.Title);
            bookCountsByTitle[indexOfBook]++;
        }

        // iterate bookCount times and try to find the best discount sets for the given book title distributions
        // TODO: fitting problem at the end is not yet solved. I.e. it is not always best to find the largest fitting set if a rest remains
        // (e.g. having a set of 5 and 3 is worse discount than having a set of 4 and 4 (if input set is 2-2-2-1-1 )
        int[] sets = new int[5];
        var i = 0;
        while (i < books.Count)
        {
            int set = 0;

            for (int j = 0; j < 5; j++)
            {
                if (bookCountsByTitle[j] > 0)
                {
                    set++;
                    bookCountsByTitle[j]--;
                    i++;
                }

                //if (set == 4)
                //{
                //    break;
                //}
            }

            sets[set-1]++;
        }

        // add prices for each set
        for (var k = 0; k < sets.Length; k++)
        {
            result += sets[k] * (k+1) * GlobalValues.BookPriceDefault * (1 - _discounts[k]);
        }

        return result;
    }

    public decimal Calculate(List<IBookSet> bookSets)
    {
        return bookSets.Sum(set => set.GetPrice());
    }

    public decimal Calculate(IBookSet bookSet)
    {
        var booksCount = bookSet.Books.Count;
        if (booksCount > _discounts.Length)
        {
            throw new ArgumentException("There are more distinct books in a set than discounts defined, please update either the BookTitle enum or the discounts definition");
        }

        return booksCount * (1 - _discounts[booksCount - 1]) * GlobalValues.BookPriceDefault;
    }
}