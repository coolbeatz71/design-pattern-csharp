using System.Text;

namespace DesignPatterns.Behavioral.Command.TextEditor;

/// <summary>
/// Represents the receiver in the Command pattern - the text editor that performs the actual text manipulation operations.
/// This class maintains the document state and provides the primitive operations that commands can invoke.
/// </summary>
/// <remarks>
/// In the Command pattern, the Receiver is the object that performs the actual work when a command is executed.
/// It knows how to perform the operations associated with carrying out a request.
/// The TextEditor serves as the receiver by providing the concrete implementation of text operations.
/// </remarks>
public class TextEditor
{
    private readonly StringBuilder _content  = new();
    
    /// <summary>
    /// Gets the current content of the text editor as a string.
    /// </summary>
    /// <returns>The complete text content currently stored in the editor.</returns>
    /// <remarks>
    /// This method provides read-only access to the editor's content state.
    /// It's used by commands that need to capture state for undo operations.
    /// </remarks>
    public string GetContent() => _content.ToString();
    
    /// <summary>
    /// Inserts the specified text at the given position in the document.
    /// </summary>
    /// <param name="text">The text to insert. Cannot be null.</param>
    /// <param name="position">The zero-based position where the text should be inserted.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="text"/> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="position"/> is negative or greater than the content length.</exception>
    /// <remarks>
    /// This method is one of the primitive operations that the receiver provides.
    /// Commands use this method to perform text insertion operations.
    /// </remarks>
    public void InsertText(string text, int position)
    {
        ArgumentNullException.ThrowIfNull(text);

        if (position < 0 || position > _content.Length)
        {
            throw new ArgumentOutOfRangeException(
                nameof(position), 
                $"Position must be between 0 and {_content.Length}"
            );
        }
        
        _content.Insert(position, text);
        Console.WriteLine($"Inserted '{text}' at position {position}");
    }
    
    /// <summary>
    /// Deletes a specified number of characters starting from the given position.
    /// </summary>
    /// <param name="position">The zero-based starting position for deletion.</param>
    /// <param name="length">The number of characters to delete.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="position"/> is negative, greater than content length,
    /// or when <paramref name="length"/> is negative or extends beyond the content length.
    /// </exception>
    /// <remarks>
    /// This method is another primitive operation provided by the receiver.
    /// Commands use this method to perform text deletion operations.
    /// </remarks>
    public void DeleteText(int position, int length)
    {
        if (position < 0 || position >= _content.Length)
        {
            throw new ArgumentOutOfRangeException(
                nameof(position),
                $"Position must be between 0 and {_content.Length - 1}"
            );
        }

        if (length < 0 || position + length > _content.Length)
        {
            throw new ArgumentOutOfRangeException(
                nameof(length),
                "Length cannot be negative or extend beyond content length"
            );
        }
        
        _content.Remove(position, length);
        Console.WriteLine($"Deleted {length} characters at position {position}");
    }
    
}