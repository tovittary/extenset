namespace Extenset.Tests;

[TestFixture]
internal sealed partial class EnumerableExtensionsTests
{
    [Test]
    public void ForEach_ActionNull_ShouldThrow()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => StringEnumerable.ForEach(NullAction!));
        Assert.Throws<ArgumentNullException>(() => StringEnumerable.ForEach(NullActionWithIndex!));
    }

    [Test]
    public void ForEach_ActionSimple_ShouldApplyAction()
    {
        // Act
        var actual = new List<string>(StringEnumerable.Length);
        StringEnumerable.ForEach(actual.Add);

        // Assert
        for (var i = 0; i < StringEnumerable.Length; i++)
            Assert.AreEqual(StringEnumerable[i], actual[i]);
    }

    [Test]
    public void ForEach_ActionWithIndex_ShouldApplyAction()
    {
        // Act
        var actual = new string[StringEnumerable.Length];
        StringEnumerable.ForEach((item, index) => actual[index] = item);

        // Assert
        for (var i = 0; i < StringEnumerable.Length; i++)
            Assert.AreEqual(StringEnumerable[i], actual[i]);
    }

    [Test]
    public void ForEach_EnumerableNull_ShouldThrow()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => NullEnumerable!.ForEach(EmptyAction));
        Assert.Throws<ArgumentNullException>(() => NullEnumerable!.ForEach(EmptyActionWithIndex));
    }
}
