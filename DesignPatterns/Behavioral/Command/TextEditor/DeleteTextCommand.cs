namespace DesignPatterns.Behavioral.Command.TextEditor;

public class DeleteTextCommand(TextEditor editor, string text, int position, int length): ICommand
{
    private readonly string _deletedText = editor.GetContent().Substring(position, length);
    
    public void Execute()
    {
        editor.DeleteText(position, length);
    }

    public void Undo()
    {
        editor.InsertText(_deletedText, position);
    }
}