namespace Abstractions;

public interface IStringToBookParser
{
    IBook Parse(string bookString);
}