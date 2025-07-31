namespace DesignPatterns.Behavioral.Memento.GoodExample;

/// <summary>
/// Represents a snapshot (memento) of an <see cref="Editor"/>'s state.
/// Stores internal data like title and content without exposing the editor’s internal structure.
/// </summary>
public class EditorMemento
{
    /// <summary>
    /// Gets the title stored in this memento.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets the content stored in this memento.
    /// </summary>
    public string Content { get; }

    /// <summary>
    /// Gets the timestamp when the memento was created.
    /// </summary>
    public DateTime Timestamp { get; }

    /// <summary>
    /// Gets a descriptive name for the memento, combining the title and timestamp.
    /// Useful for display in history logs.
    /// </summary>
    public string Name => $"({Title})-{Timestamp}";

    /// <summary>
    /// Initializes a new instance of the <see cref="EditorMemento"/> class.
    /// This constructor is internal and is intended to be used only by the <see cref="Editor"/>.
    /// </summary>
    /// <param name="title">The title to save.</param>
    /// <param name="content">The content to save.</param>
    internal EditorMemento(string title, string content)
    {
        Title = title;
        Content = content;
        Timestamp = DateTime.Now;
    }
}
