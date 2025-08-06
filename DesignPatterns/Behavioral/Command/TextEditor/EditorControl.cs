namespace DesignPatterns.Behavioral.Command.TextEditor;

/// <summary>
/// Represents the invoker in the Command pattern - manages command execution and provides undo/redo functionality.
/// This class decouples the user interface from the business logic by using commands as intermediaries.
/// </summary>
/// <remarks>
/// <para>
/// In the Command pattern, the Invoker is responsible for initiating requests. It holds a reference to
/// a command object and can invoke the command's Execute method. The EditorControl serves as the invoker
/// by managing a collection of commands and providing higher-level operations like undo and redo.
/// </para>
/// 
/// <para>This implementation uses two stacks to maintain command history:</para>
/// <list type="bullet">
///     <item>Undo stack: Contains commands that can be undone (most recent command on top)</item>
///     <item>Redo stack: Contains commands that can be redone (cleared when new commands are executed)</item>
/// </list>
/// 
/// <para>
/// The invoker doesn't need to know the specifics of how commands work - it just calls Execute() and Undo()
/// methods, demonstrating the loose coupling achieved by the Command pattern.
/// </para>
/// </remarks>
public class EditorControl
{
    private readonly Stack<ICommand> _undoStack = new();
    private readonly Stack<ICommand> _redoStack = new();
    
    /// <summary>
    /// Executes the specified command and adds it to the undo history.
    /// This method provides the primary interface for command execution in the system.
    /// </summary>
    /// <param name="command">The command to execute. Cannot be null.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="command"/> is null.</exception>
    /// <remarks>
    /// <para>This method demonstrates the core of the Command pattern's invoker responsibility:</para>
    /// <list type="number">
    ///     <item>Execute the command by calling its Execute() method</item>
    ///     <item>Store the command for potential undo operations</item>
    ///     <item>Clear the redo stack since executing a new command invalidates any previously undone operations</item>
    /// </list>
    /// <para>The invoker doesn't need to know what the command does - it just provides the execution framework.
    /// This enables runtime composition of operations and supports features like macro recording,
    /// queuing, and logging.</para>
    /// </remarks>
    public void ExecuteCommand(ICommand command)
    {
        ArgumentNullException.ThrowIfNull(command);
        
        command.Execute();
        _undoStack.Push(command);
        
        // Clear redo stack when new command is executed
        // This maintains logical consistency - you can't redo operations after executing new ones
        _redoStack.Clear();
    }
    
    /// <summary>
    /// Undoes the most recently executed command, if any commands are available to undo.
    /// </summary>
    /// <returns>True if an operation was undone; false if no operations were available to undo.</returns>
    /// <remarks>
    /// <para>This method implements the undo functionality by:</para>
    /// <list type="number">
    ///     <item>Checking if there are any commands to undo</item>
    ///     <item>Popping the most recent command from the undo stack</item>
    ///     <item>Calling the command's Undo() method to reverse its effects</item>
    ///     <item>Pushing the command onto the redo stack for potential redo operations</item>
    /// </list>
    /// <para>
    /// The Command pattern makes undo implementation straightforward because each command
    /// knows how to reverse its own operation.
    /// </para>
    /// </remarks>
    public bool Undo()
    {
        if (_undoStack.Count <= 0) return false;
        
        var command = _undoStack.Pop();
        command.Undo();
        _redoStack.Push(command);
        
        return true;
    }
    
    /// <summary>
    /// Redoes the most recently undone command, if any commands are available to redo.
    /// </summary>
    /// <returns>True if an operation was redone; false if no operations were available to redo.</returns>
    /// <remarks>
    /// <para>This method implements the redo functionality by:</para>
    /// <list type="number">
    ///     <item>Checking if there are any commands to redo</item>
    ///     <item>Popping the most recent undone command from the redo stack</item>
    ///     <item>Re-executing the command by calling its Execute() method</item>
    ///     <item>Pushing the command back onto the undo stack</item>
    /// </list>
    /// <para>Redo is essentially re-executing a previously undone command, which demonstrates
    /// the symmetry and elegance of the Command pattern.
    /// </para>
    /// </remarks>
    public bool Redo()
    {
        if (_redoStack.Count <= 0) return false;
        
        var command = _redoStack.Pop();
        command.Execute();
        _undoStack.Push(command);

        return true;
    }
}