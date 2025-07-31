namespace DesignPatterns.Behavioral.Memento.GoodExample;

/// <summary>
/// Represents the Caretaker in the Memento design pattern.
/// Maintains a history stack of <see cref="Editor"/> states through mementos and enables undo functionality.
/// </summary>
public class EditorHistory(Editor editor)
{
    private readonly Stack<EditorMemento> _statesList = new();

    /// <summary>
    /// Saves the current state of the associated <see cref="Editor"/> into the history.
    /// </summary>
    public void Save()
    {
        var memento = editor.SaveState();
        _statesList.Push(memento);
    }

    /// <summary>
    /// Restores the editor to the most recently saved state.
    /// Displays a message if no states are available to undo.
    /// </summary>
    public void Undo()
    {
        if (_statesList.Count <= 0)
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
