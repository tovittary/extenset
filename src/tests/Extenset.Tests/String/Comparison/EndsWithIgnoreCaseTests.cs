namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    [TestCase("Testing", "gn")]
    [TestCase("Testing", "test")]
    public void EndsWithIgnoreCase_DoesNotEndWith_ShouldReturnFalse(string @string, string value)
    {
        // Act
        var actual = @string.EndsWithIgnoreCase(value);

        // Assert
        Assert.False(actual);
    }

    [TestCase("Testing", "")]
    [TestCase("Testing", "iNg")]
    [TestCase("Testing", "ting")]
    public void EndsWithIgnoreCase_EndsWith_ShouldReturnTrue(string @string, string value)
    {
        // Act
        var actual = @string.EndsWithIgnoreCase(value);

        // Assert
        Assert.True(actual);
    }

    [TestCase("", null)]
    [TestCase(null, "")]
    [TestCase(null, null)]
    public void EndsWithIgnoreCase_StringOrValueNull_ShouldThrow(string @string, string value) =>
        Assert.Throws<ArgumentNullException>(() => @string.EndsWithIgnoreCase(value));
}
