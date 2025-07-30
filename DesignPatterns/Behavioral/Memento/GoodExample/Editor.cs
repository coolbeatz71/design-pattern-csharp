namespace DesignPatterns.Behavioral.Memento.GoodExample;

// Originator
public class Editor(string title, string content, DateTime timestamp)
{
    private string Title { get; set; } = title;
    private string Content { get; set; } = content;

    public DateTime Timestamp { get; private set; } = timestamp;

    public EditorMemento CreateMemento()
    {
        Console.WriteLine("Creating memento...");
        return new EditorMemento(Title, Content);
    }

    public void RestoreFromMemento(EditorMemento memento)
    {
        Console.WriteLine($"Restored to state from {memento.Timestamp}");
        Console.WriteLine($"Title: {Title}, Content: {Content}");
        
        Title = memento.Title;
        Content = memento.Content;
    }
}