namespace Abstractions;

public enum BookTitle
{
    Book1, Book2, Book3, Book4, Book5
}

public static class BookTitles
{
    static BookTitles()
    {
        All = Enum.GetValues<BookTitle>();
    }
    public static BookTitle[] All { get; private set; }
}