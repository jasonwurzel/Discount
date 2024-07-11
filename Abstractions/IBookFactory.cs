namespace Abstractions;

public interface IBookFactory
{
    IBook CreateBook(BookTitle title);
}