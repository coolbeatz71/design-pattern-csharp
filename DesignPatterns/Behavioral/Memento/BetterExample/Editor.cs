using DesignPatterns.Behavioral.Memento.BetterExample.Contracts;

namespace DesignPatterns.Behavioral.Memento.BetterExample;

public class Editor(string title, string content): IOriginator<EditorMemento>
{
    private string  Title { get; set; } = title;
    private string Content { get; set; } = content;
    
    private DateTime CreatedAt { get; } = DateTime.Now;

    public void Edit(string newTitle, string newContent)
    {
        if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(newTitle))
        {
            throw new ArgumentException("Title and content cannot be null or whitespace");
        }
        
        Title = newTitle;
        Content = newContent;
    }

    public EditorMemento SaveState() => new(Title, Content);

    public void RestoreState(EditorMemento memento)
    {
        Title = memento.Title;
        Content = memento.Content;
        Console.WriteLine($"Restored to: {memento.Name}");
    }

    public void Show()
    {
        Console.WriteLine($"{Title}: {Content}");
        Console.WriteLine("------------------");
    }
}