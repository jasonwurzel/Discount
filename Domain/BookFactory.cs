using Abstractions;

namespace Domain;

public class BookFactory : IBookFactory
{
    public IBook CreateBook(BookTitle title)
    {
        return new Book(title);
    }
}