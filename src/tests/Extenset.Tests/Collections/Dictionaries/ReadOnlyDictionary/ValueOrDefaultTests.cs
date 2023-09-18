namespace Extenset.Tests;

[TestFixture]
internal sealed class ReadOnlyDictionaryExtensionsTests
{
    [Test]
    public void ValueOrDefault_DictionaryNull_ShouldThrow()
    {
        // Arrange
        const string key = "key";
        IReadOnlyDictionary<string, string>? dictionary = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => dictionary!.ValueOrDefault(key));
    }

    [Test]
    public void ValueOrDefault_KeyFound_ShouldReturnValue()
    {
        // Arrange
        const string key = "key";
        const string expected = "value";
        IReadOnlyDictionary<string, string> dictionary = new Dictionary<string, string> { { key, expected } };

        // Act
        var actual = dictionary.ValueOrDefault(key);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ValueOrDefault_KeyNotFound_ShouldReturnDefault()
    {
        // Arrange
        const string key = "key";
        IReadOnlyDictionary<string, string> dictionary = new Dictionary<string, string>();

        // Act
        var actual = dictionary.ValueOrDefault(key);

        // Assert
        Assert.AreEqual(null, actual);
    }

    [Test]
    public void ValueOrDefault_KeyNull_ShouldThrow()
    {
        // Arrange
        IReadOnlyDictionary<string, string> dictionary = new Dictionary<string, string>();

        // Assert
        Assert.Throws<ArgumentNullException>(() => dictionary.ValueOrDefault(null!));
    }
}
