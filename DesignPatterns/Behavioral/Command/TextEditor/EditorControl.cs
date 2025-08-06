namespace DesignPatterns.Behavioral.Command.TextEditor;

// Invoker - manages commands and provides undo/redo functionality
public class EditorControl
{
    private readonly Stack<ICommand> _undoStack = new();
    private readonly Stack<ICommand> _redoStack = new();
    
    // Allow the ability to swap commands at runtime
    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _undoStack.Push(command);
        
        // Clear redo stack when new command is executed
        _redoStack.Clear();
    }

    public void Undo()
    {
        if (_undoStack.Count <= 0) return;
        
        var command = _undoStack.Pop();
        command.Undo();
        _redoStack.Push(command);
    }

    public void Redo()
    {
        if (_redoStack.Count <= 0) return;
        var command = _redoStack.Pop();
        command.Execute();
        _undoStack.Push(command);
    }
}