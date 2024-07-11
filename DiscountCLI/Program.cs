using Abstractions;
using Logic;

namespace DiscountCLI;

internal class Program
{
    static void Main(string[] args)
    {
        IBookToStringPrinter printer = new BookToStringPrinter();
        Console.WriteLine("Please run the Unit Tests");
    }
}