namespace Extenset;

using System.Xml;

/// <summary>
/// Extension methods for <see cref="XmlWriter" />.
/// </summary>
public static partial class XmlWriterExtensions
{
    /// <summary>
    /// Asynchronously writes the attribute with the specified name and value
    /// and without any associations with namespace or prefix.
    /// </summary>
    /// <param name="writer">The <see cref="XmlWriter" /> instance.</param>
    /// <param name="name">The qualified name of the attribute.</param>
    /// <param name="value">The value of the attribute.</param>
    /// <returns>
    /// The <see cref="Task" /> that represents the asynchronous attribute write operation.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="writer" />, <paramref name="name" /> or <paramref name="value" /> is
    /// <c>null</c> or empty.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// <see cref="XmlWriter.WriteAttributeStringAsync" />.
    /// </exception>
    public static Task WriteAttributeStringAsync(this XmlWriter writer, string name, string value)
    {
        if (writer is null) throw new ArgumentNullException(nameof(writer));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (value is null) throw new ArgumentNullException(nameof(value));

        return writer.WriteAttributeStringAsync(string.Empty, name, string.Empty, value);
    }
}
