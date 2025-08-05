namespace DesignPatterns.Behavioral.Command.DocumentEditor;

public class UndoCommand(HistoryManager history): ICommand
{
    public void Execute()
    {
        if (history.Count() <= 0) return;
        
        var lastCommand = history.Pop();
        lastCommand.Undo();
    }
}