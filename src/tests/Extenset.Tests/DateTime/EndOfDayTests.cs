namespace Extenset.Tests;

[TestFixture]
internal sealed class DateTimeExtensionsTests
{
    [Test]
    public void EndOfDay_ShouldReturnEndOfDay()
    {
        // Arrange
        var dateTime = new DateTime(2023, 09, 06, 13, 54, 27);
        var expected = new DateTime(638_296_415_999_999_999);

        // Act
        var actual = dateTime.EndOfDay();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
