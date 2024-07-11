using Abstractions;
using Domain;
using FluentAssertions;
using Logic;
using UnitTests.Logic.Mocks;
using Xunit;

namespace UnitTests.Logic;

public class BookSetCalculatorTests
{
    [Theory]
    [MemberData(nameof(DataForCalculateListOfBooks))]
    public void CalculateListOfBooks(List<IBook> books, decimal expectedPrice)
    {
        // Arrange
        var sut = new BookSetCalculator();

        // Act
        var result = sut.Calculate(books);

        // Assert
        result.Should().Be(expectedPrice);
    }

    public static TheoryData<List<IBook>, decimal> DataForCalculateListOfBooks =>
        new()
        {
            {
                [
                    new DummyBook(BookTitle.Book1),
                    new DummyBook(BookTitle.Book2),
                    new DummyBook(BookTitle.Book3),
                    new DummyBook(BookTitle.Book4),
                    new DummyBook(BookTitle.Book5),
                    new DummyBook(BookTitle.Book1),
                    new DummyBook(BookTitle.Book2),
                    new DummyBook(BookTitle.Book3)
                ],
                51.20m
            },
            {
                [
                    new DummyBook(BookTitle.Book1),
                    new DummyBook(BookTitle.Book2),
                    new DummyBook(BookTitle.Book3),
                    new DummyBook(BookTitle.Book4),
                    new DummyBook(BookTitle.Book5),
                    new DummyBook(BookTitle.Book1),
                    new DummyBook(BookTitle.Book2),
                    new DummyBook(BookTitle.Book3),
                    new DummyBook(BookTitle.Book4),
                    new DummyBook(BookTitle.Book5)
                ],
                60.00m
            },
            {
                [
                    new DummyBook(BookTitle.Book1),
                    new DummyBook(BookTitle.Book1)
                ],
                16.00m
            },
            {
                [
                    new DummyBook(BookTitle.Book1),
                    new DummyBook(BookTitle.Book2)
                ],
                15.20m
            },
            {
                [
                    new DummyBook(BookTitle.Book1),
                    new DummyBook(BookTitle.Book2),
                    new DummyBook(BookTitle.Book3)
                ],
                21.60m
            },
            {
                [
                    new DummyBook(BookTitle.Book1),
                    new DummyBook(BookTitle.Book2),
                    new DummyBook(BookTitle.Book2)
                ],
                23.20m
            },
            {
                [
                    new DummyBook(BookTitle.Book1)
                ],
                8.00m
            },
            {
                [],
                0.00m
            }

        };

    [Fact]
    public void CalculateSingleBookSet01()
    {
        // Arrange
        var sut = new BookSetCalculator();
        var set1 = new BookSet(sut);
        set1.TryAddBook(new DummyBook(BookTitle.Book1));
        set1.TryAddBook(new DummyBook(BookTitle.Book2));
        set1.TryAddBook(new DummyBook(BookTitle.Book3));
        set1.TryAddBook(new DummyBook(BookTitle.Book4));
        set1.TryAddBook(new DummyBook(BookTitle.Book5));

        // Act
        var result = sut.Calculate(set1);

        // Assert
        result.Should().Be(30m);
    }
}