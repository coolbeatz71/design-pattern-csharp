namespace DesignPatterns.Behavioral.Command.DocumentEditor;

public class BoldCommand(HTMLDocument document, HistoryManager history): IUndoableCommand
{
    /// <summary>
    /// Stores the document's content state before the bold operation is applied.
    /// This field is essential for the undo functionality, preserving the exact
    /// state that existed prior to command execution.
    /// </summary>
    private string _prevContent = "";
    
    /// <summary>
    /// Executes the bold formatting command on the document.
    /// This method saves the current state, applies bold formatting,
    /// and adds itself to the command history for potential undo operations.
    /// </summary>
    /// <remarks>
    /// <list type="number">
    /// <item>Save current state for undo capability</item>
    /// <item>Delegate actual work to receiver (HTMLDocument.MakeBold())</item>
    /// <item>Register with history manager for undo tracking</item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// var command = new BoldCommand(document, history);
    /// command.Execute();
    /// 
    /// // The command is now in history and can be undone
    /// Console.WriteLine(history.Count()); // Output: 1
    /// </code>
    /// </example>
    public void Execute()
    {
        _prevContent = document.Content;
        document.MakeBold();
        history.Push(this);
    }
    
    /// <summary>
    /// Undoes the bold formatting by restoring the document's previous content.
    /// This method implements the undo functionality by directly setting
    /// the document content to its pre-execution state.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item>Restores exact content that existed before Execute() was called</item>
    /// <item>Does not re-add itself to history avoiding infinite loops</item>
    /// <item>Provides immediate state restoration without side effects</item>
    /// <item>Should only be undone after execution otherwise _prevContent will be empty</item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// var command = new BoldCommand(document, history);
    /// string original = document.Content;
    /// 
    /// command.Execute();
    /// // Content is now formatted
    /// 
    /// command.Undo();
    /// Assert.AreEqual(original, document.Content); // Content is restored
    /// </code>
    /// </example>
    public void Undo()
    {
        document.Content = _prevContent;
    }
}