namespace DesignPatterns.Behavioral.Iterator.GoodExample.Contracts;

/// <summary>
/// Interface for a collection that creates an iterator.
/// Implements the Aggregate pattern, allowing collections to provide
/// uniform access to their elements through iterators.
/// </summary>
/// <typeparam name="T">The type of elements in the collection.</typeparam>
public interface IAggregate<out T>
{
    /// <summary>
    /// Creates an iterator to traverse the collection.
    /// </summary>
    /// <returns>An iterator for the collection that implements <see cref="IIterator{T}"/>.</returns>
    /// <remarks>
    /// Each call to this method should return a new iterator instance
    /// positioned at the beginning of the collection.
    /// </remarks>
    IIterator<T> CreateIterator();
}