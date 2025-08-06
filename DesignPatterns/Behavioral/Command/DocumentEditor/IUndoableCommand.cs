namespace DesignPatterns.Behavioral.Command.DocumentEditor;

/// <summary>
/// Extends ICommand to support undoable operations.
/// This interface is crucial for implementing undo/redo functionality
/// in the document editor using the Command pattern combined with the Memento pattern.
/// </summary>
/// <remarks>
/// <list type="bullet">
/// <item>Must save their previous state before executing</item>
/// <item>Must be able to restore previous state when Undo() is called</item>
/// <item>Must add themselves to history manager during execution</item>
/// <item>Enable creation of robust undo system</item>
/// <item>Support complex document editing workflows</item>
/// </list>
/// </remarks>
public interface IUndoableCommand: ICommand
{
    /// <summary>
    /// Reverses the operation performed by Execute().
    /// This method restores the receiver to its previous state,
    /// effectively undoing the command's changes.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item>Restore the exact state that existed before Execute() was called</item>
    /// <item>Not add itself back to history to avoid infinite loops</item>
    /// <item>Be callable multiple times with same result (idempotent)</item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// var command = new ItalicCommand(document, history);
    /// string originalContent = document.Content;
    /// 
    /// command.Execute();
    /// // document.Content is now modified
    /// 
    /// command.Undo();
    /// // document.Content is restored to originalContent
    /// </code>
    /// </example>
    void Undo();
}