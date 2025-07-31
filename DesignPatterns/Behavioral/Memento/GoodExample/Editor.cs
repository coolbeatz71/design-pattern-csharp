namespace DesignPatterns.Behavioral.Memento.GoodExample;

/// <summary>
/// Represents the Originator in the Memento pattern.
/// Maintains the state (title and content) and can create or restore a memento.
/// </summary>
/// <example>
/// Example usage in a Main method:
/// <code>
/// var editor = new Editor("Initial Title", "Initial Content", DateTime.Now);
/// var history = new EditorHistory(editor);
///
/// history.Save();
/// editor.RestoreFromMemento(new EditorMemento("Updated Title", "Updated Content"));
/// editor.Show();
///
/// history.Undo();
/// editor.Show();
/// </code>
/// </example>
public class Editor(string title, string content)
{

    /// <summary>
    /// Gets or sets the title of the editor's current state.
    /// </summary>
    public string Title { get; set; } = title;

    /// <summary>
    /// Gets or sets the content of the editor's current state.
    /// </summary>
    public string Content { get; set; } = content;

    /// <summary>
    /// Gets the timestamp when the editor was first created.
    /// </summary>
    private DateTime Timestamp { get; set; } = DateTime.Now;

    /// <summary>
    /// Creates a memento that captures the current state of the editor.
    /// </summary>
    /// <returns>An <see cref="EditorMemento"/> containing the current title and content.</returns>
    public EditorMemento SaveState()
    {
        Console.WriteLine("Creating memento...");
        Console.WriteLine("------------------");
        
        return new EditorMemento(Title, Content);
    }

    /// <summary>
    /// Restores the editor's state from the specified memento.
    /// </summary>
    /// <param name="memento">The memento from which to restore state.</param>
    public void RestoreState(EditorMemento memento)
    {
        Console.WriteLine($"Restored to state from {memento.Timestamp} - {memento.Title}");
        
        Title = memento.Title;
        Content = memento.Content;
    }

    /// <summary>
    /// Displays the current state of the editor.
    /// </summary>
    public void Show()
    {
        Console.WriteLine($"title: {Title}");
        Console.WriteLine($"content: {Content}");
        Console.WriteLine("------------------");
    }
}
