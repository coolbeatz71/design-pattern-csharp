namespace DesignPatterns.Behavioral.Memento.GoodExample;

/// <summary>
/// Represents the Caretaker in the Memento pattern.
/// Responsible for storing and restoring <see cref="Editor"/> states via mementos.
/// </summary>
public class EditorHistory(Editor editor)
{
    private readonly Stack<EditorMemento> _statesList = [];

    /// <summary>
    /// Saves the current state of the associated editor to the history list.
    /// </summary>
    public void Save()
    {
        var memento = editor.SaveState();
        _statesList.Push(memento);
    }

    /// <summary>
    /// Restores the editor to its most recently saved state.
    /// If no states are available, a message is printed.
    /// </summary>
    public void Undo()
    {
        if (_statesList.Count == 0)
        {
            Console.WriteLine("No more states to undo");
            return;
        }

        var memento = _statesList.Pop();
        editor.RestoreState(memento);
    }

    /// <summary>
    /// Displays all stored history entries for the editor.
    /// </summary>
    public void ShowHistory()
    {
        foreach (var state in _statesList)
        {
            Console.WriteLine($"History: {state.Name}");
        }
    }
}