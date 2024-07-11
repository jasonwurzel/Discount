using Abstractions;
using Domain;
using FluentAssertions;
using UnitTests.Domain.Mocks;
using Xunit;

namespace UnitTests.Domain;

public class ShoppingCartTests
{
    [Fact]
    public void TestAddBook()
    {
        // Arrange
        var sut = new ShoppingCart(new DummyBookSetCalculator());
        var dummyBook = new DummyBook(BookTitle.Book1);

        // Act
        sut.AddBook(dummyBook);
        
        // Assert
        sut.Books.Should().HaveCount(1);
        sut.Books.Single().Should().BeSameAs(dummyBook);
    }

    [Fact]
    public void TestGetPrice()
    {
        // Arrange
        var expectedPrice = 12m;
        var sut = new ShoppingCart(new DummyBookSetCalculator(expectedPrice));
        var dummyBook = new DummyBook(BookTitle.Book1);
        sut.AddBook(dummyBook);

        // Act
        var price = sut.GetPrice();

        // Assert
        price.Should().Be(expectedPrice);
    }

}