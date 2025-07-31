namespace DesignPatterns.Behavioral.Memento.BetterExample.Contracts;

/// <summary>
/// Represents a caretaker that manages the history of states for an originator.
/// </summary>
/// <remarks>
/// The caretaker is responsible for saving and restoring the originator's state without
/// inspecting or modifying the memento's internal contents.
/// It typically maintains a history stack to enable undo/redo functionality.
/// </remarks>
public interface ICaretaker
{
    /// <summary>
    /// Saves the current state of the originator by capturing a new memento.
    /// </summary>
    void Save();

    /// <summary>
    /// Restores the originator's most recently saved state.
    /// If no history is available, this operation has no effect.
    /// </summary>
    void Undo();

    /// <summary>
    /// Displays all stored mementos or history entries, typically for debugging or UI display.
    /// </summary>
    void ShowHistory();
}