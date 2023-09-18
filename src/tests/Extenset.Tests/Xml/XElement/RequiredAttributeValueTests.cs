namespace Extenset.Tests;

using System.Xml.Linq;

[TestFixture]
internal sealed class XElementExtensionsTests
{
    [Test]
    public void RequiredAttributeValue_ElementNull_ShouldThrow()
    {
        // Arrange
        XElement? nullElement = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullElement!.RequiredAttributeValue(string.Empty));
    }

    [TestCase("")]
    [TestCase(null)]
    public void RequiredAttributeValue_NameNullOrEmpty_ShouldThrow(string name)
    {
        // Arrange
        var element = new XElement("Element");

        // Assert
        Assert.Throws<ArgumentNullException>(() => element.RequiredAttributeValue(name));
    }

    [Test]
    public void RequiredAttributeValue_AttributePresent_ShouldReturnValue()
    {
        // Arrange
        const string attributeName = "AttributeName";
        const string attributeValue = "AttributeValue";
        var element = new XElement("Element");
        element.Add(new XAttribute(attributeName, attributeValue));

        // Act
        var actual = element.RequiredAttributeValue(attributeName);

        // Assert
        Assert.AreEqual(attributeValue, actual);
    }

    [Test]
    public void RequiredAttributeValue_AttributeNotPresent_ShouldThrow()
    {
        // Arrange
        const string attributeName = "AttributeName";
        var element = new XElement("Element");

        // Assert
        Assert.Throws<ArgumentException>(() => element.RequiredAttributeValue(attributeName));
    }
}
