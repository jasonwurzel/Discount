using Abstractions;

namespace Domain;

public class BookFactory : IBookFactory
{
    public IBook CreateBook(PossibleBookTitles title)
    {
        return new Book(title);
    }
}