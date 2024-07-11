using Abstractions;

namespace UnitTests.Domain.Mocks;

public class DummyBook : IBook
{
    public DummyBook(BookTitle title)
    {
        Title = title;
    }

    public BookTitle Title { get; }
}