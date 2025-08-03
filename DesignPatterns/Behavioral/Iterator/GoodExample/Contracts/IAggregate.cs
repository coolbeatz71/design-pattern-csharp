namespace DesignPatterns.Behavioral.Iterator.GoodExample.Contracts;

/// <summary>
/// Interface for a collection that creates an iterator.
/// </summary>
/// <typeparam name="T">The type of elements in the collection.</typeparam>
public interface IAggregate<out T>
{
    /// <summary>
    /// Creates an iterator to traverse the collection.
    /// </summary>
    /// <returns>An iterator for the collection.</returns>
    IIterator<T> CreateIterator();
}