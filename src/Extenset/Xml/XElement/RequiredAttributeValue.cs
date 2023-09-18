namespace Extenset;

using System.Xml.Linq;

/// <summary>
/// Extension methods for <see cref="XElement" />.
/// </summary>
public static class XElementExtensions
{
    /// <summary>
    /// Returns the value of the <see cref="XElement" /> attribute with the specified name.
    /// </summary>
    /// <param name="element">The <see cref="XElement" /> instance.</param>
    /// <param name="name">The qualified name of the attribute.</param>
    /// <returns>The value of the attribute.</returns>
    /// <exception cref="ArgumentException">Attribute not found.</exception>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="element" /> or <paramref name="name" /> is <c>null</c> or empty.
    /// </exception>
    public static string RequiredAttributeValue(this XElement element, string name)
    {
        if (element is null) throw new ArgumentNullException(nameof(element));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

        var attribute = element.Attribute(name);
        if (attribute is null)
        {
            throw new ArgumentException(
                $"Could not find the attribute '{name}' on the element '{element.Name}'.");
        }

        return attribute.Value;
    }
}
