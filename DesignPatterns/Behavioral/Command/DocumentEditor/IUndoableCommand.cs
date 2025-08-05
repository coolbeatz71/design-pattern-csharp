namespace DesignPatterns.Behavioral.Command.DocumentEditor;

public interface IUndoableCommand: ICommand
{
    void Undo();
}