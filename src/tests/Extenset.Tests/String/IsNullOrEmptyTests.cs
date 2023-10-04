namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    [Test]
    public void IsNullOrEmpty_NotEmpty_ShouldReturnFalse()
    {
        // Arrange
        const string @string = "Testing";

        // Act
        var actual = @string.IsNullOrEmpty();

        // Assert
        Assert.False(actual);
    }

    [TestCase("")]
    [TestCase(null)]
    public void IsNullOrEmpty_NullOrEmpty_ShouldReturnTrue(string? @string)
    {
        // Act
        var actual = @string.IsNullOrEmpty();

        // Assert
        Assert.True(actual);
    }

    [Test]
    public void IsNullOrEmpty_WhitespacesOnly_ShouldReturnFalse()
    {
        // Arrange
        const string @string = "   ";

        // Act
        var actual = @string.IsNullOrEmpty();

        // Assert
        Assert.False(actual);
    }
}
