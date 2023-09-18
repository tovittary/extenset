namespace Extenset;

using System.Xml;

/// <summary>
/// Extension methods for <see cref="XmlReader" />.
/// </summary>
public static partial class XmlReaderExtensions
{
    /// <summary>
    /// Gets the <see cref="bool" /> value of the attribute with the specified name.
    /// </summary>
    /// <param name="reader">The <see cref="XmlReader" /> instance.</param>
    /// <param name="name">The qualified name of the attribute.</param>
    /// <returns>
    /// The <see cref="bool" /> value of the specified attribute.
    /// If the attribute is not found or the value is String.Empty, <c>false</c> is returned.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="reader" /> or <paramref name="name" /> is <c>null</c> or empty.
    /// </exception>
    public static bool GetBooleanAttribute(this XmlReader reader, string name)
    {
        if (reader is null) throw new ArgumentNullException(nameof(reader));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

        var value = reader.GetAttribute(name);
        if (string.IsNullOrEmpty(value))
            return default;

        return bool.TryParse(value, out var boolValue) && boolValue;
    }
}
