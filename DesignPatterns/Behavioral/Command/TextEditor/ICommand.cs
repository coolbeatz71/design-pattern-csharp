namespace DesignPatterns.Behavioral.Command.TextEditor;

public interface ICommand
{
    void Execute();
    void Undo();
}