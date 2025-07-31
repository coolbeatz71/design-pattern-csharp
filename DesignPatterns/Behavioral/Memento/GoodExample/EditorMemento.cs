namespace DesignPatterns.Behavioral.Memento.GoodExample;

/// <summary>
/// Represents a snapshot (Memento) of the <see cref="Editor"/> state.
/// Used to store the internal state of the Editor without exposing implementation details.
/// </summary>
public class EditorMemento
{
    /// <summary>
    /// Gets the title saved in this memento.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets the content saved in this memento.
    /// </summary>
    public string Content { get; }

    /// <summary>
    /// Gets the timestamp indicating when the memento was created.
    /// </summary>
    public DateTime Timestamp { get; }

    /// <summary>
    /// Gets a human-readable name of this memento.
    /// Combines the timestamp and title for display purposes.
    /// </summary>
    public string Name => $"{Timestamp} / ({Title})";

    /// <summary>
    /// Initializes a new instance of the <see cref="EditorMemento"/> class.
    /// This constructor is internal and only accessible by the <see cref="Editor"/>.
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