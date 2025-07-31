namespace DesignPatterns.Behavioral.Memento.BetterExample.Contracts;

/// <summary>
/// Represents an originator in the Memento design pattern.
/// </summary>
/// <typeparam name="TMemento">A type that implements <see cref="IMemento"/> and captures the state of the originator.</typeparam>
/// <remarks>
/// An originator is any object whose state needs to be saved and restored.
/// It provides the ability to create a new memento representing its current state
/// and to restore itself from a given memento.
/// </remarks>
public interface IOriginator<TMemento> where TMemento : IMemento
{
    /// <summary>
    /// Captures the current state of the object and returns it as a memento.
    /// </summary>
    /// <returns>A new instance of <typeparamref name="TMemento"/> containing the saved state.</returns>
    TMemento SaveState();

    /// <summary>
    /// Restores the object's state from the provided memento.
    /// </summary>
    /// <param name="memento">The memento from which to restore the state.</param>
    void RestoreState(TMemento memento);
}