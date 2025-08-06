namespace DesignPatterns.Behavioral.Command.TextEditor;

/// <summary>
/// Concrete command implementation for inserting text into a text editor.
/// This class encapsulates a text insertion request, including all the information needed
/// to perform the operation and its reverse operation (undo).
/// </summary>
/// <remarks>
/// In the Command pattern, this represents a ConcreteCommand that defines a binding between
/// a Receiver object (TextEditor) and an action (insert text). It implements Execute by
/// invoking the corresponding operation(s) on the Receiver.
/// 
/// The command stores the necessary parameters (text and position) to perform the operation
/// and implements both Execute and Undo methods to support reversible operations.
/// <param name="editor">The text editor instance that will receive the command. Cannot be null.</param>
/// <param name="text">The text to be inserted. Cannot be null.</param>
/// <param name="position">The position where the text should be inserted.</param>
/// <exception cref="ArgumentNullException">Thrown when <paramref name="editor"/> or <paramref name="text"/> is null.</exception>
/// <remarks>
/// The constructor captures all the information needed to execute the command later.
/// This demonstrates the Command pattern's ability to encapsulate a request as an object.
/// </remarks>
/// </remarks>
public class InsertTextCommand(TextEditor editor, string text, int position) : ICommand
{
    private readonly TextEditor _editor = editor ?? throw new ArgumentNullException(nameof(editor));
    private readonly string _text = text ?? throw new ArgumentNullException(nameof(text));

    /// <summary>
    /// Executes the insert text operation by delegating to the receiver (TextEditor).
    /// </summary>
    /// <remarks>
    /// This method implements the Command pattern's Execute method by calling the appropriate
    /// method on the receiver object with the stored parameters.
    /// </remarks>
    public void Execute()
    {
        _editor.InsertText(_text, position);
    }
    
    /// <summary>
    /// Undoes the insert text operation by deleting the previously inserted text.
    /// </summary>
    /// <remarks>
    /// This method provides the reverse operation by removing the exact text that was inserted.
    /// It demonstrates how commands can maintain enough state to reverse their operations.
    /// </remarks>
    public void Undo()
    {
        _editor.DeleteText(position, _text.Length);
    }
}