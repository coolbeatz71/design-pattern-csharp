namespace DesignPatterns.Behavioral.Command.DocumentEditor;

/// <summary>
/// Concrete command that applies italic formatting to an HTML document.
/// This class demonstrates the Command pattern by encapsulating the italic formatting
/// request and implementing both execute and undo functionality.
/// </summary>
/// <remarks>
/// <list type="bullet">
/// <item>Encapsulates the italic formatting operation</item>
/// <item>Maintains state necessary for undo operations</item>
/// <item>Delegates actual formatting work to HTMLDocument (receiver)</item>
/// <item>Integrates with history management system</item>
/// <item>Saves document's previous content before applying formatting</item>
/// <item>Enables precise undo operations that restore exact previous state</item>
/// </list>
/// </remarks>
/// <param name="document">The HTML document to format (Receiver)</param>
/// <param name="history">The history manager for undo functionality</param>
/// <example>
/// <code>
/// var document = new HTMLDocument("Hello World");
/// var history = new HistoryManager();
/// var italicCommand = new ItalicCommand(document, history);
/// 
/// Console.WriteLine(document.Content); // Output: Hello World
/// 
/// italicCommand.Execute();
/// Console.WriteLine(document.Content); // Output: &lt;i&gt;Hello World&lt;/i&gt;
/// 
/// italicCommand.Undo();
/// Console.WriteLine(document.Content); // Output: Hello World
/// </code>
/// </example>
public class ItalicCommand(HTMLDocument document, HistoryManager history) : IUndoableCommand
{
    /// <summary>
    /// Stores the document's content state before the italic operation is applied.
    /// This field is essential for the undo functionality, preserving the exact
    /// state that existed prior to command execution.
    /// </summary>
    private string _prevContent = "";
    
    /// <summary>
    /// Executes the italic formatting command on the document.
    /// This method saves the current state, applies italic formatting,
    /// and adds itself to the command history for potential undo operations.
    /// </summary>
    /// <remarks>
    /// <list type="number">
    /// <item>Save current state for undo capability</item>
    /// <item>Delegate actual work to receiver (HTMLDocument.MakeItalic())</item>
    /// <item>Register with history manager for undo tracking</item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// var command = new ItalicCommand(document, history);
    /// command.Execute();
    /// 
    /// // The command is now in history and can be undone
    /// Console.WriteLine(history.Count()); // Output: 1
    /// </code>
    /// </example>
    public void Execute()
    {
        _prevContent = document.Content;
        // delegating the work to the document business logic (Receiver)
        document.MakeItalic();
        history.Push(this);
    }
    
    /// <summary>
    /// Undoes the italic formatting by restoring the document's previous content.
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
    /// var command = new ItalicCommand(document, history);
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