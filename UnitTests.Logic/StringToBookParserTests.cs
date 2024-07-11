using Abstractions;
using Domain;
using FluentAssertions;
using Logic;
using Xunit;

namespace UnitTests.Logic;

public class StringToBookParserTests
{
    [Fact]
    public void TestParse()
    {
        // Arrange
        var sut = new StringToBookParser(new BookFactory());
        string input = "Book1";

        // Act
        var result = sut.Parse(input);

        // Assert
        result.Title.Should().Be(BookTitle.Book1);
    }

}