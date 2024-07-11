using Abstractions;

namespace Logic
{
    public class BookToStringPrinter : IBookToStringPrinter
    {
        public string Print(IBook book)
        {
            return book.Title.ToString();
        }

        public string PrintAll()
        {
            return string.Join(", ", Enum.GetNames<BookTitle>());
        }
    }
}
