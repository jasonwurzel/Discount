namespace Abstractions;

public interface IBookToStringPrinter
{
    string Print(IBook book);
    string PrintAll();
}