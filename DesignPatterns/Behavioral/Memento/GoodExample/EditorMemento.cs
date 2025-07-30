namespace DesignPatterns.Behavioral.Memento.GoodExample;

// Memento
public class EditorMemento
{
    public string Title { get; }
    public string Content { get; }
    public DateTime Timestamp { get; }
    public string Name => $"{Timestamp} / ({Title})";

    internal EditorMemento(string title, string content)
    {
        Title = title;
        Content = content;
        Timestamp = DateTime.Now;
    }
}