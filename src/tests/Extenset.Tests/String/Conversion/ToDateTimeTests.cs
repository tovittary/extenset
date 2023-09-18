namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    [TestCase("")]
    [TestCase("10.09.2023T12:44:53")]
    [TestCase("12-44-53")]
    [TestCase("13/10/23")]
    public void ToDateTime_InvalidFormat_ShouldThrow(string dateTimeString) =>
        Assert.Throws<FormatException>(() => dateTimeString.ToDateTime());

    [Test]
    public void ToDateTime_StringNull_ShouldThrow()
    {
        // Arrange
        string? nullString = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullString!.ToDateTime());
    }

    [TestCase("10.09.2023 12:44:53")]
    [TestCase("2023-09-10T12:45:08.4724300+03:00")]
    [TestCase("9.10.23")]
    [TestCase("2023 - 09 - 10")]
    public void ToDateTime_ValidFormat_ShouldReturnDateTime(string dateTimeString)
    {
        // Act
        var actual = dateTimeString.ToDateTime();

        // Assert
        Assert.AreNotEqual(default(DateTime), actual);
    }

    [TestCase("", "dd.MM.yyyy")]
    [TestCase("10.09.2023 12:44:53", "dd.MM.yyyy")]
    [TestCase("2023-09-10T12:45:08.4724300+03:00", "dd-yyyy-MM")]
    [TestCase("9.10.23", "")]
    public void ToDateTime_WithFormat_InvalidFormat_ShouldThrow(string dateTimeString, string format) =>
        Assert.Throws<FormatException>(() => dateTimeString.ToDateTime(format));

    [TestCase(null, "")]
    [TestCase("", null)]
    [TestCase(null, null)]
    public void ToDateTime_WithFormat_StringOrFormatNull_ShouldThrow(string dateTimeString, string format) =>
        Assert.Throws<ArgumentNullException>(() => dateTimeString.ToDateTime(format));

    [TestCase("10.09.2023 12:44:53", "dd.MM.yyyy HH:mm:ss")]
    [TestCase("2023-09-10T12:45:08.4724300+03:00", "o")]
    [TestCase("9.10.23", "M.dd.yy")]
    public void ToDateTime_WithFormat_ValidFormat_ShouldReturnDateTime(string dateTimeString, string format)
    {
        // Act
        var actual = dateTimeString.ToDateTime(format);

        // Assert
        Assert.AreNotEqual(default(DateTime), actual);
    }
}
