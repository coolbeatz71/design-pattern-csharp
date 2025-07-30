namespace DesignPatterns.Behavioral.Memento.GoodExample;

// Caretaker
public class EditorHistory(Editor editor)
{
    private readonly List<EditorMemento> _states = [];

    public void Save()
    {
        var memento = editor.CreateMemento();
        _states.Add(memento);
        Console.WriteLine($"State saved. History count: {_states.Count}");
    }

    public void Undo()
    {
        if (_states.Count <= 0)
        {
            Console.WriteLine("No more states to undo");
        }
        else
        {
            var memento = _states.Last();
            _states.Remove(memento);
            editor.RestoreFromMemento(memento);
            Console.WriteLine($"Undo performed. History count: {_states.Count}");
        }
    }

    public void ShowHistory()
    {
        foreach (var state in _states)
        {
            Console.WriteLine($"History count: {state.Name}");
        }
    }
}