namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    [Test]
    public void IsNullOrWhitespace_NotEmpty_ShouldReturnFalse()
    {
        // Arrange
        const string @string = " Testing ";

        // Act
        var actual = @string.IsNullOrWhitespace();

        // Assert
        Assert.False(actual);
    }

    [TestCase("")]
    [TestCase(null)]
    public void IsNullOrWhitespace_NullOrEmpty_ShouldReturnTrue(string? @string)
    {
        // Act
        var actual = @string.IsNullOrWhitespace();

        // Assert
        Assert.True(actual);
    }

    [Test]
    public void IsNullOrWhitespace_WhitespacesOnly_ShouldReturnTrue()
    {
        // Arrange
        const string @string = "   ";

        // Act
        var actual = @string.IsNullOrWhitespace();

        // Assert
        Assert.True(actual);
    }
}
