namespace DesignPatterns.Behavioral.Iterator.GoodExample.Contracts;

/// <summary>
/// Defines a generic iterator interface that provides
/// methods to traverse a collection without exposing its internal structure.
/// Implements the Iterator pattern for uniform collection traversal.
/// </summary>
/// <typeparam name="T">The type of elements returned by the iterator.</typeparam>
/// <remarks>
/// This interface follows the standard iterator pattern where:
/// - <see cref="HasNext"/> checks for availability of next element
/// - <see cref="Next"/> advances the iterator position
/// - <see cref="Current"/> retrieves the current element
/// </remarks>
public interface IIterator<out T>
{
    /// <summary>
    /// Moves the iterator to the next element in the collection.
    /// </summary>
    /// <remarks>
    /// This method should be called after <see cref="HasNext"/> returns true.
    /// Calling this method when <see cref="HasNext"/> returns false may result
    /// in undefined behavior.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown when attempting to move beyond the end of the collection.
    /// </exception>
    void Next();

    /// <summary>
    /// Determines if there are more elements to iterate over.
    /// </summary>
    /// <returns>
    /// <c>true</c> if more elements exist and <see cref="Next"/> can be safely called;
    /// otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method should be called before <see cref="Next"/> and <see cref="Current"/>
    /// to ensure safe iteration through the collection.
    /// </remarks>
    bool HasNext();

    /// <summary>
    /// Returns the current element in the collection.
    /// </summary>
    /// <returns>The current element of type <typeparamref name="T"/>.</returns>
    /// <remarks>
    /// This method should only be called when <see cref="HasNext"/> returns true.
    /// The behavior is undefined if called when the iterator is positioned
    /// beyond the end of the collection.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown when attempting to access current element when iterator
    /// is not positioned on a valid element.
    /// </exception>
    T Current();
}