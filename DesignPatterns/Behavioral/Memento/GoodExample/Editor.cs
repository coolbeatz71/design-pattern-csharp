namespace DesignPatterns.Behavioral.Memento.GoodExample;

/// <summary>
/// Represents the Originator in the Memento design pattern.
/// Maintains the current state (title and content) and allows saving or restoring this state using mementos.
/// </summary>
/// <example>
/// Example usage:
/// <code>
/// var editor = new Editor("Initial Title", "Initial Content");
/// var history = new EditorHistory(editor);
///
/// history.Save();
/// editor.Edit("Updated Title", "Updated Content");
/// editor.Show();
///
/// history.Undo();
/// editor.Show();
/// </code>
/// </example>
public class Editor(string title, string content)
{
    /// <summary>
    /// Gets or sets the title of the current document.
    /// </summary>
    private string Title { get; set; } = title;

    /// <summary>
    /// Gets or sets the content of the current document.
    /// </summary>
    private string Content { get; set; } = content;

    /// <summary>
    /// Gets the timestamp when the editor instance was created.
    /// </summary>
    private DateTime Timestamp { get; set; } = DateTime.Now;

    /// <summary>
    /// Updates the title and content of the document.
    /// </summary>
    /// <param name="newTitle">The new title to set.</param>
    /// <param name="newContent">The new content to set.</param>
    public void Edit(string newTitle, string newContent)
    {
        if (string.IsNullOrWhiteSpace(newTitle) || string.IsNullOrWhiteSpace(newContent))
        {
            Console.WriteLine("Invalid update: title or content cannot be empty.");
            return;
        }

        Title = newTitle;
        Content = newContent;
    }

    /// <summary>
    /// Creates a memento object representing the current state of the editor.
    /// </summary>
    /// <returns>A new <see cref="EditorMemento"/> instance capturing the current title and content.</returns>
    public EditorMemento SaveState()
    {
        Console.WriteLine("Creating memento...");
        Console.WriteLine("------------------");

        return new EditorMemento(Title, Content);
    }

    /// <summary>
    /// Restores the editor's state using a previously created memento.
    /// </summary>
    /// <param name="memento">The <see cref="EditorMemento"/> from which to restore the state.</param>
    public void RestoreState(EditorMemento memento)
    {
        Console.WriteLine($"Restored to state from {memento.Timestamp} - {memento.Title}");

        Title = memento.Title;
        Content = memento.Content;
    }

    /// <summary>
    /// Displays the current title and content of the editor.
    /// </summary>
    public void Show()
    {
        Console.WriteLine($"title: {Title}");
        Console.WriteLine($"content: {Content}");
        Console.WriteLine("------------------");
    }
}