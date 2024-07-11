using Abstractions;

namespace UnitTests.Logic.Mocks;

public class DummyBook : IBook
{
    public DummyBook(BookTitle title)
    {
        Title = title;
    }

    public BookTitle Title { get; }
}