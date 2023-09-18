namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    [TestCase("")]
    [TestCase("123-456")]
    [TestCase("abc")]
    public void ToDoubleInvariant_InvalidFormat_ShouldThrow(string doubleString) =>
        Assert.Throws<FormatException>(() => doubleString.ToDoubleInvariant());

    [Test]
    public void ToDoubleInvariant_StringNull_ShouldThrow()
    {
        // Arrange
        string? nullString = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullString!.ToDoubleInvariant());
    }

    [TestCase("123")]
    [TestCase("123.456")]
    [TestCase("123,456")]
    public void ToDoubleInvariant_ValidFormat_ShouldReturnDouble(string doubleString)
    {
        // Act
        var actual = doubleString.ToDoubleInvariant();

        // Assert
        Assert.AreNotEqual(default(double), actual);
    }
}
