namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    [TestCase("Testing", "Testing")]
    [TestCase("Testing", "testing")]
    [TestCase("Testing", "TESTING")]
    public void EqualsIgnoreCase_Equals_ShouldReturnTrue(string @string, string value)
    {
        // Act
        var actual = @string.EqualsIgnoreCase(value);

        // Assert
        Assert.True(actual);
    }

    [TestCase("Testing", "")]
    [TestCase("Testing", "test")]
    [TestCase("Testing", "testings")]
    public void EqualsIgnoreCase_DoesNotEqual_ShouldReturnFalse(string @string, string value)
    {
        // Act
        var actual = @string.EqualsIgnoreCase(value);

        // Assert
        Assert.False(actual);
    }

    [TestCase("", null)]
    [TestCase(null, "")]
    [TestCase(null, null)]
    public void EqualsIgnoreCase_StringOrValueNull_ShouldThrow(string @string, string value) =>
        Assert.Throws<ArgumentNullException>(() => @string.EqualsIgnoreCase(value));
}
