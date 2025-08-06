namespace DesignPatterns.Behavioral.Command.TextEditor;

public class InsertTextCommand(TextEditor editor, string text, int position): ICommand
{
    public void Execute()
    {
        editor.InsertText(text, position);
    }

    public void Undo()
    {
        editor.DeleteText(position, text.Length);
    }
}