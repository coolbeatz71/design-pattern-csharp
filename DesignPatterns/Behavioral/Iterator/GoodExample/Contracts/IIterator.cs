namespace DesignPatterns.Behavioral.Iterator.GoodExample.Contracts;

/// <summary>
/// Defines a generic iterator interface that provides
/// methods to traverse a collection without exposing its structure.
/// </summary>
/// <typeparam name="T">The type of elements returned by the iterator.</typeparam>
public interface IIterator<out T>
{
    /// <summary>
    /// Moves the iterator to the next element.
    /// </summary>
    void Next();

    /// <summary>
    /// Determines if there are more elements to iterate over.
    /// </summary>
    /// <returns>True if more elements exist; otherwise, false.</returns>
    bool HasNext();

    /// <summary>
    /// Returns the current element in the collection.
    /// </summary>
    /// <returns>The current element.</returns>
    T Current();
}