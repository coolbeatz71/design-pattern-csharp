using DesignPatterns.Behavioral.Memento.BetterExample.Contracts;

namespace DesignPatterns.Behavioral.Memento.BetterExample;

public class EditorHistory(IOriginator<EditorMemento> editor): ICaretaker
{
    private readonly Stack<EditorMemento> _history = new();
    
    public void Save()
    {
        var memento = editor.SaveState();
        _history.Push(memento);
    }

    public void Undo()
    {
        if (_history.Count <= 0)
        {
            Console.WriteLine("No more states to undo");
            return;
        }
        
        var memento = _history.Pop();
        editor.RestoreState(memento);
    }

    public void ShowHistory()
    {
        foreach (var memento in _history)
        {
            Console.WriteLine($"History: {memento.Name}");
        }
    }
}