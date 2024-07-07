namespace Abstractions;

public interface IBookFactory
{
    IBook CreateBook(PossibleBookTitles title);
}