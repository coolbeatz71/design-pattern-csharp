using DesignPatterns.Behavioral.Memento.BetterExample.Contracts;

namespace DesignPatterns.Behavioral.Memento.BetterExample;

public class EditorMemento: IMemento
{
    public string Title { get; }
    public string Content { get; }
    public DateTime Timestamp { get; }
    
    public string Name => $"({Title})-{Timestamp:yyyyMMdd_HHmmss}";

    internal EditorMemento(string title, string content)
    {
        Title = title;
        Content = content;
        Timestamp = DateTime.Now;
    }
}