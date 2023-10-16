namespace Extenset.Tests;

internal sealed partial class DateTimeExtensionsTests
{
    [Test]
    public void ToUnixTimeSpan_ValidDateTime_ShouldReturnTimeSpan()
    {
        // Arrange
        var expected = new TimeSpan(19647, 12, 26, 13);
        var dateTime = new DateTime(2023, 10, 17, 12, 26, 13);

        // Act
        var actual = dateTime.ToUnixTimeSpan();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ToUnixTimeSpan_DateTimeTooEarly_ShouldThrow()
    {
        // Arrange
        var dateTime = new DateTime(1900, 1, 1);

        // Assert
        Assert.Throws<ArgumentException>(() => dateTime.ToUnixTimeSpan());
    }
}
