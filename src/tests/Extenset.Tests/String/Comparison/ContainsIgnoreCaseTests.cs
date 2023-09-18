namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    [TestCase("Testing", "")]
    [TestCase("Testing", "STI")]
    [TestCase("Testing", "Test")]
    public void ContainsIgnoreCase_Contains_ShouldReturnTrue(string @string, string value)
    {
        // Act
        var actual = @string.ContainsIgnoreCase(value);

        // Assert
        Assert.True(actual);
    }

    [TestCase("Testing", "abc")]
    [TestCase("Testing", "qwerty")]
    [TestCase("Testing", "some other string")]
    public void ContainsIgnoreCase_DoesNotContain_ShouldReturnFalse(string @string, string value)
    {
        // Act
        var actual = @string.ContainsIgnoreCase(value);

        // Assert
        Assert.False(actual);
    }

    [TestCase("", null)]
    [TestCase(null, "")]
    [TestCase(null, null)]
    public void ContainsIgnoreCase_StringOrValueNull_ShouldThrow(string @string, string value) =>
        Assert.Throws<ArgumentNullException>(() => @string.ContainsIgnoreCase(value));
}
