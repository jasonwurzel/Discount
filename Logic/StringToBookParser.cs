using Abstractions;
using Domain;

namespace Logic;

public class StringToBookParser : IStringToBookParser
{
    private readonly BookFactory _bookFactory;

    public StringToBookParser(BookFactory bookFactory)
    {
        _bookFactory = bookFactory;
    }

    public IBook Parse(string bookString)
    {
        if (Enum.TryParse<BookTitle>(bookString, out var result))
        {
            return _bookFactory.CreateBook(result);
        }

        throw new ArgumentException(Message.StringToBookParser_Parse_Book_not_found);
    }
}