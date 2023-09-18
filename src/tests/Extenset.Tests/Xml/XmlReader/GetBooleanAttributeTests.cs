namespace Extenset.Tests;

using System.Text;
using System.Xml;

[TestFixture]
internal sealed partial class XmlReaderExtensionsTests
{
    [TestCase("")]
    [TestCase(null)]
    public static void GetBooleanAttribute_NameNullOrEmpty_ShouldThrow(string name)
    {
        // Arrange
        using var stream = new MemoryStream();
        using var reader = XmlReader.Create(stream);

        // Assert
        Assert.Throws<ArgumentNullException>(() => reader.GetBooleanAttribute(name));
    }

    [Test]
    public static async Task GetBooleanAttribute_NameValid_ShouldReturnBoolean()
    {
        // Arrange
        const string attributeName = "attributeName";
        const string elementName = "Element";

        var bytes = Encoding.ASCII.GetBytes(XmlDocumentWithBoolString);
        using var stream = new MemoryStream(bytes);
        using var reader = XmlReader.Create(stream, new XmlReaderSettings { Async = true });

        // Act
        bool? actual = null;
        while (await reader.ReadAsync())
        {
            if (reader is { NodeType: XmlNodeType.Element, Name: elementName })
                actual = reader.GetBooleanAttribute(attributeName);
        }

        // Assert
        Assert.True(actual.HasValue);
        Assert.True(actual!.Value);
    }

    [Test]
    public static void GetBooleanAttribute_ReaderNull_ShouldThrow()
    {
        // Arrange
        XmlReader? nullReader = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullReader!.GetBooleanAttribute(string.Empty));
    }
}
