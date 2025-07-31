namespace DesignPatterns.Behavioral.Memento.BetterExample.Contracts;

/// <summary>
/// Represents an immutable snapshot of an object's state at a specific point in time.
/// </summary>
/// <remarks>
/// Used in the Memento design pattern to encapsulate and store the internal state
/// of an originator without exposing its structure. This interface is domain-agnostic
/// and intended for use across different modules and entities.
/// </remarks>
public interface IMemento
{
    /// <summary>
    /// Gets the timestamp indicating when the memento was created.
    /// </summary>
    DateTime Timestamp { get; }

    /// <summary>
    /// Gets a human-readable name or label for this memento.
    /// This is typically used for display purposes, such as in history logs or UI timelines.
    /// </summary>
    string Name { get; }
}