namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    [TestCase("")]
    [TestCase("123-456")]
    [TestCase("9223372036854775807")]
    [TestCase("abc")]
    public void ToInt_InvalidFormat_ShouldThrow(string intString) =>
        Assert.Throws<FormatException>(() => intString.ToInt());

    [Test]
    public void ToInt_StringNull_ShouldThrow()
    {
        // Arrange
        string? nullString = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullString!.ToInt());
    }

    [TestCase("123")]
    [TestCase("2147483647")]
    public void ToInt_ValidFormat_ShouldReturnInt(string intString)
    {
        // Act
        var actual = intString.ToInt();

        // Assert
        Assert.AreNotEqual(default(int), actual);
    }
}
