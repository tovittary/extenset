namespace Extenset.Tests;

[TestFixture]
internal sealed class DictionaryExtensionsTests
{
    [Test]
    public void ValueOrDefault_DictionaryNull_ShouldThrow()
    {
        // Arrange
        const string key = "key";
        Dictionary<string, string>? dictionary = null;
        IDictionary<string, string>? asInterface = dictionary;

        // Assert
        Assert.Throws<ArgumentNullException>(() => dictionary!.ValueOrDefault(key));
        Assert.Throws<ArgumentNullException>(() => asInterface!.ValueOrDefault(key));
    }

    [Test]
    public void ValueOrDefault_KeyFound_ShouldReturnValue()
    {
        // Arrange
        const string key = "key";
        const string expected = "value";
        var dictionary = new Dictionary<string, string> { { key, expected } };
        IDictionary<string, string> asInterface = dictionary;

        // Act
        var actual = dictionary.ValueOrDefault(key);
        var actualAsInterface = asInterface.ValueOrDefault(key);

        // Assert
        Assert.AreEqual(expected, actual);
        Assert.AreEqual(expected, actualAsInterface);
    }

    [Test]
    public void ValueOrDefault_KeyNotFound_ShouldReturnDefault()
    {
        // Arrange
        const string key = "key";
        var dictionary = new Dictionary<string, string>();
        IDictionary<string, string> asInterface = dictionary;

        // Act
        var actual = dictionary.ValueOrDefault(key);
        var actualAsInterface = asInterface.ValueOrDefault(key);

        // Assert
        Assert.AreEqual(null, actual);
        Assert.AreEqual(null, actualAsInterface);
    }

    [Test]
    public void ValueOrDefault_KeyNull_ShouldThrow()
    {
        // Arrange
        var dictionary = new Dictionary<string, string>();
        IDictionary<string, string> asInterface = dictionary;

        // Assert
        Assert.Throws<ArgumentNullException>(() => dictionary.ValueOrDefault(null!));
        Assert.Throws<ArgumentNullException>(() => asInterface.ValueOrDefault(null!));
    }
}
