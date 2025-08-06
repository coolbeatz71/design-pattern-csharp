namespace DesignPatterns.Behavioral.Command.TextEditor;

/// <summary>
/// Concrete command implementation for deleting text from a text editor.
/// This class encapsulates a text deletion request and captures the deleted content
/// to enable undo functionality.
/// </summary>
/// <remarks>
/// This ConcreteCommand demonstrates an important aspect of the Command pattern:
/// commands can capture state before executing to enable undo operations.
/// The deleted text is stored during construction to allow restoration during undo.
/// 
/// <para>
/// Note: This implementation captures the text during construction, which means
/// the command must be created immediately before execution to ensure data consistency.
/// </para>
/// </remarks>
public class DeleteTextCommand: ICommand
{
    private readonly TextEditor _editor;
    private readonly int _position;
    private readonly int _length;
    private readonly string _deletedText;
    
    /// <summary>
    /// Initializes a new instance of the DeleteTextCommand class.
    /// </summary>
    /// <param name="editor">The text editor instance that will receive the command. Cannot be null.</param>
    /// <param name="position">The starting position for text deletion.</param>
    /// <param name="length">The number of characters to delete.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="editor"/> is null.</exception>
    /// <remarks>
    /// The constructor captures the text that will be deleted before the operation is executed.
    /// This is necessary for implementing the undo functionality. The command pattern allows
    /// this kind of state capture to support complex undo/redo scenarios.
    ///
    /// <para>
    /// <b>IMPORTANT:</b> This command should be executed immediately after creation to maintain
    /// data consistency, as it captures the current state of the document.
    /// </para>
    /// </remarks>
    public DeleteTextCommand(TextEditor editor, int position, int length)
    {
        _editor = editor ?? throw new ArgumentNullException(nameof(editor));
        _position = position;
        _length = length;

        var content = _editor.GetContent();
        if (position >= 0 && position < content.Length && position + length <= content.Length)
        {
            _deletedText = content.Substring(position, length);
        }
        else
        {
            _deletedText = string.Empty;
        }
    }
    
    /// <summary>
    /// Executes the delete text operation by delegating to the receiver (TextEditor).
    /// </summary>
    /// <remarks>
    /// This method implements the Command pattern's Execute method by calling the delete
    /// operation on the receiver with the stored parameters.
    /// </remarks>
    public void Execute()
    {
        _editor.DeleteText(_position, _length);
    }
    
    /// <summary>
    /// Undoes the delete text operation by reinserting the previously deleted text.
    /// </summary>
    /// <remarks>
    /// This method restores the editor to its previous state by inserting the captured
    /// deleted text back at its original position. This demonstrates how the Command pattern
    /// enables sophisticated undo functionality by maintaining operation history.
    /// </remarks>
    public void Undo()
    {
        if (!string.IsNullOrEmpty(_deletedText))
        {
            _editor.InsertText(_deletedText, _position);
        }
    }
}