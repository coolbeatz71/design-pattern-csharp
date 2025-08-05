namespace DesignPatterns.Behavioral.Command.DocumentEditor;

public class ItalicCommand(HTMLDocument document, HistoryManager history) : IUndoableCommand
{
    private HTMLDocument _document = document;
    private HistoryManager _history = history;
    private string _prevContent = "";

    public void Execute()
    {
        _prevContent = _document.Content;
        // delegating the work to the document business logic
        _document.MakeItalic();
        _history.Push(this);
    }

    public void Undo()
    {
        _document.Content = _prevContent;
    }
}