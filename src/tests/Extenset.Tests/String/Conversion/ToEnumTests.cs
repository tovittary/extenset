namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    internal enum TestEnum
    {
        First,
        Second,
        Third
    }

    [Test]
    public void ToEnum_EnumStringNull_ShouldThrow()
    {
        // Arrange
        string? enumString = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => enumString!.ToEnum<TestEnum>());
    }

    [TestCase("first", TestEnum.First)]
    [TestCase("second", TestEnum.Second)]
    [TestCase("third", TestEnum.Third)]
    public void ToEnum_IgnoreCase_ValidEnumString_ShouldReturnValue(string enumString, TestEnum expected)
    {
        // Act
        var actual = enumString.ToEnum<TestEnum>(true);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestCase("")]
    [TestCase("fourth")]
    public void ToEnum_IgnoreCase_InvalidEnumString_ShouldThrow(string enumString) =>
        Assert.Throws<ArgumentException>(() => enumString.ToEnum<TestEnum>(true));

    [TestCase("First", TestEnum.First)]
    [TestCase("Second", TestEnum.Second)]
    [TestCase("Third", TestEnum.Third)]
    public void ToEnum_RegardCase_ValidEnumString_ShouldReturnValue(string enumString, TestEnum expected)
    {
        // Act
        var actual = enumString.ToEnum<TestEnum>();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestCase("")]
    [TestCase("first")]
    [TestCase("fourth")]
    public void ToEnum_RegardCase_InvalidEnumString_ShouldThrow(string enumString) =>
        Assert.Throws<ArgumentException>(() => enumString.ToEnum<TestEnum>());
}
