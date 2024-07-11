using Abstractions;
using Domain;
using FluentAssertions;
using Logic;
using UnitTests.Domain.Mocks;
using Xunit;

namespace UnitTests.Domain;

public class BookSetTests
{
    [Fact]
    public void TestAddBookToBookSet()
    {
        // Arrange
        IBookSetCalculator dummyCalculator = new DummyBookSetCalculator();
        var sut = new BookSet(dummyCalculator);
        var bookFactory = new BookFactory();
        var book1 = bookFactory.CreateBook(BookTitle.Book1);
        var book1_1 = bookFactory.CreateBook(BookTitle.Book1);
        var book2 = bookFactory.CreateBook(BookTitle.Book2);
        var book2_2 = bookFactory.CreateBook(BookTitle.Book2);

        // Act && Assert
        sut.TryAddBook(book1).Should().BeTrue();
        sut.TryAddBook(book1_1).Should().BeFalse();
        sut.TryAddBook(book2).Should().BeTrue();

        sut.Books.Should().HaveCount(2);
        sut.Books.ElementAt(0).Should().BeSameAs(book1);
        sut.Books.ElementAt(1).Should().BeSameAs(book2);
        sut.Books.Should().NotContain(b => object.ReferenceEquals(b, book2_2));
    }

    [Fact]
    public void TestGetPrice()
    {
        // Arrange
        IBookSetCalculator calculator = new BookSetCalculator();
        var sut = new BookSet(calculator);
        var bookFactory = new BookFactory();
        var book1 = bookFactory.CreateBook(BookTitle.Book1);
        var book2 = bookFactory.CreateBook(BookTitle.Book2);

        // Act && Assert
        sut.TryAddBook(book1).Should().BeTrue();
        sut.TryAddBook(book2).Should().BeTrue();

        sut.GetPrice().Should().Be(15.2m);
    }
}