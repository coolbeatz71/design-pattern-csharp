namespace DesignPatterns.Behavioral.Command.DocumentEditor;

/// <summary>
/// Manages the history of executed commands for undo functionality.
/// This class implements the Memento pattern alongside the Command pattern
/// to provide undo/redo capabilities in the document editor.
/// </summary>
/// <remarks>
/// <list type="bullet">
/// <item>Acts as the Caretaker in the Memento pattern</item>
/// <item>Stores command objects that can reverse their operations</item>
/// <item>Maintains a stack-like structure using a List for command history</item>
/// </list>
/// </remarks>
/// <example>
/// <code>
/// var history = new HistoryManager();
/// var document = new HTMLDocument("Hello World");
/// var italicCommand = new ItalicCommand(document, history);
/// 
/// // Execute command - it will automatically be added to history
/// italicCommand.Execute();
/// Console.WriteLine(document.Content); // Output: &lt;i&gt;Hello World&lt;/i&gt;
/// 
/// // Undo the last command
/// if (history.Count() > 0)
/// {
///     var lastCommand = history.Pop();
///     lastCommand.Undo();
///     Console.WriteLine(document.Content); // Output: Hello World
/// }
/// </code>
/// </example>
public class HistoryManager
{
    /// <summary>
    /// Internal storage for executed undoable commands.
    /// Commands are stored in execution order, with the most recent at the end.
    /// </summary>
    private readonly List<IUndoableCommand> _commands = [];
    
    /// <summary>
    /// Adds a command to the history stack.
    /// This method is typically called automatically by commands during their execution.
    /// </summary>
    /// <param name="command">The undoable command to store in history</param>
    /// <exception cref="ArgumentNullException">Thrown when command is null</exception>
    /// <example>
    /// <code>
    /// var history = new HistoryManager();
    /// var command = new ItalicCommand(document, history);
    /// history.Push(command); // Usually called internally by command.Execute()
    /// </code>
    /// </example>
    public void Push(IUndoableCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);
        _commands.Add(command);
    }
    
    /// <summary>
    /// Removes and returns the most recently executed command from history.
    /// This follows LIFO (Last In, First Out) behavior for proper undo functionality.
    /// </summary>
    /// <returns>The most recent undoable command</returns>
    /// <exception cref="InvalidOperationException">Thrown when trying to pop from empty history</exception>
    /// <example>
    /// <code>
    /// var history = new HistoryManager();
    /// // ... after executing some commands
    /// 
    /// if (history.Count() > 0)
    /// {
    ///     var lastCommand = history.Pop();
    ///     lastCommand.Undo();
    /// }
    /// </code>
    /// </example>
    public IUndoableCommand Pop()
    {
        if (_commands.Count == 0)
        {
            throw new InvalidOperationException("Cannot pop from empty command history");
        }
        
        var last = _commands[^1];
        _commands.RemoveAt(_commands.Count - 1);
        return last;
    }
    
    /// <summary>
    /// Gets the number of commands currently stored in history.
    /// </summary>
    /// <returns>The count of undoable commands in history</returns>
    /// <example>
    /// <code>
    /// var history = new HistoryManager();
    /// Console.WriteLine(history.Count()); // Output: 0
    /// 
    /// // After executing commands...
    /// Console.WriteLine(history.Count()); // Output: number of executed commands
    /// </code>
    /// </example>
    public int Count() => _commands.Count;
}