namespace Extenset.Tests;

using System.Text;
using System.Xml;

[TestFixture]
internal sealed partial class XmlReaderExtensionsTests
{
    [Test]
    public static void ReadToFollowingAsync_ReaderNull_ShouldThrow()
    {
        // Arrange
        XmlReader? nullReader = null;

        // Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => nullReader!.ReadToFollowingAsync());
    }

    [Test]
    public static async Task ReadToFollowingAsync_ReaderValid_ShouldReadToElements()
    {
        // Arrange
        const string firstElementName = "FirstElement";

        var bytes = Encoding.ASCII.GetBytes(XmlDocumentString);
        using var stream = new MemoryStream(bytes);
        using var reader = XmlReader.Create(stream, new XmlReaderSettings { Async = true });

        // Act
        await reader.ReadAsync();
        await reader.ReadToFollowingAsync();

        // Assert
        Assert.True(reader.NodeType == XmlNodeType.Element);
        Assert.AreEqual(firstElementName, reader.Name);
    }

    [TestCase("")]
    [TestCase(null)]
    public static void ReadToFollowingAsync_WithName_NameNullOrEmpty_ShouldThrow(string name)
    {
        // Arrange
        using var stream = new MemoryStream();
        using var reader = XmlReader.Create(stream);

        // Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => reader.ReadToFollowingAsync(name));
    }

    [Test]
    public static void ReadToFollowingAsync_WithName_ReaderNull_ShouldThrow()
    {
        // Arrange
        XmlReader? nullReader = null;

        // Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => nullReader!.ReadToFollowingAsync(string.Empty));
    }

    [Test]
    public static async Task ReadToFollowingAsync_WithName_ReaderValid_ShouldReadToSpecifiedElement()
    {
        // Arrange
        const string secondElementName = "SecondElement";

        var bytes = Encoding.ASCII.GetBytes(XmlDocumentString);
        using var stream = new MemoryStream(bytes);
        using var reader = XmlReader.Create(stream, new XmlReaderSettings { Async = true });

        // Act
        await reader.ReadToFollowingAsync(secondElementName);

        // Assert
        Assert.True(reader.NodeType == XmlNodeType.Element);
        Assert.AreEqual(secondElementName, reader.Name);
    }
}
