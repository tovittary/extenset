namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    [TestCase("")]
    [TestCase("123-456")]
    [TestCase("9223372036854775808")]
    [TestCase("abc")]
    public void ToLong_InvalidFormat_ShouldThrow(string longString) =>
        Assert.Throws<FormatException>(() => longString.ToLong());

    [Test]
    public void ToLong_StringNull_ShouldThrow()
    {
        // Arrange
        string? nullString = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullString!.ToLong());
    }

    [TestCase("123")]
    [TestCase("2147483647")]
    [TestCase("9223372036854775807")]
    public void ToLong_ValidFormat_ShouldReturnLong(string longString)
    {
        // Act
        var actual = longString.ToLong();

        // Assert
        Assert.AreNotEqual(default(long), actual);
    }
}
