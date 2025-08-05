namespace DesignPatterns.Behavioral.Command.DocumentEditor;

/// <summary>
/// Meta-command that undoes the last executed command in the history.
/// This class implements a special type of command that operates on other commands,
/// demonstrating how the Command pattern can be used to build complex command hierarchies.
/// </summary>
/// <remarks>
/// <list type="bullet">
/// <item>Retrieves the most recent command from history</item>
/// <item>Executes that command's undo operation</item>
/// <item>Removes the command from history since it's been undone</item>
/// <item>Allows undo functionality to be treated as just another command</item>
/// <item>Enables consistent handling of all operations in the system</item>
/// <item>Supports potential creation of redo functionality</item>
/// </list>
/// </remarks>
/// <param name="history">The history manager containing commands to undo</param>
/// <example>
/// <code>
/// var document = new HTMLDocument("Hello");
/// var history = new HistoryManager();
/// 
/// // Execute some commands
/// var italicCmd = new ItalicCommand(document, history);
/// italicCmd.Execute(); // Content: "&lt;i&gt;Hello&lt;/i&gt;"
/// 
/// // Create and execute undo command
/// var undoCmd = new UndoCommand(history);
/// undoCmd.Execute(); // Content: "Hello" (back to original)
/// 
/// Console.WriteLine(history.Count()); // Output: 0 (history is now empty)
/// </code>
/// </example>
public class UndoCommand(HistoryManager history): ICommand
{
    /// <summary>
    /// Executes the undo operation by retrieving and undoing the most recent command.
    /// This method implements the meta-command behavior of operating on other commands
    /// rather than directly on document content.
    /// </summary>
    /// <remarks>
    /// <list type="number">
    /// <item>Checks if there are any commands to undo (defensive programming)</item>
    /// <item>Retrieves the most recent command from history (LIFO order)</item>
    /// <item>Calls the command's Undo() method to reverse its operation</item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// var undoCommand = new UndoCommand(history);
    /// 
    /// // Safe to call even with empty history
    /// undoCommand.Execute(); // Does nothing if history is empty
    /// 
    /// // After executing some other commands
    /// italicCommand.Execute();
    /// undoCommand.Execute(); // Undoes the italic command
    /// </code>
    /// </example>
    public void Execute()
    {
        if (history.Count() <= 0) return;
        
        var lastCommand = history.Pop();
        lastCommand.Undo();
    }
}