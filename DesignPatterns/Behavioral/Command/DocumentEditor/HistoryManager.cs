namespace DesignPatterns.Behavioral.Command.DocumentEditor;

public class HistoryManager
{
    private readonly List<IUndoableCommand> _commands = [];

    public void Push(IUndoableCommand command)
    {
        _commands.Add(command);
    }

    public IUndoableCommand Pop()
    {
        var last = _commands[^1];
        _commands.Remove(last);
        return last;
    }
    
    public int Count() => _commands.Count;
}