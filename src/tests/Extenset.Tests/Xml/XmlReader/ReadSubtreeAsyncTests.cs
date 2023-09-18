namespace Extenset.Tests;

using System.Text;
using System.Xml;

[TestFixture]
internal sealed partial class XmlReaderExtensionsTests
{
    [Test]
    public static void ReadSubtreeAsync_ReaderNull_ShouldThrow()
    {
        // Arrange
        XmlReader? nullReader = null;

        // Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => nullReader!.ReadSubtreeAsync());
    }

    [Test]
    public static async Task ReadSubtreeAsync_ReaderValid_ShouldReturnSubtreeReader()
    {
        // Arrange
        const string subtreeName = "Subtree";

        var bytes = Encoding.ASCII.GetBytes(XmlDocumentWithSubtreeString);
        using var stream = new MemoryStream(bytes);
        using var reader = XmlReader.Create(stream, new XmlReaderSettings { Async = true });

        // Act
        var subtreeRead = false;
        while (await reader.ReadAsync())
        {
            if (reader is not { NodeType: XmlNodeType.Element, Name: subtreeName })
                continue;

            using var subtreeReader = await reader.ReadSubtreeAsync();
            subtreeRead = true;
        }

        // Assert
        Assert.True(subtreeRead);
    }
}
