namespace DesignPatterns.Behavioral.Command.DocumentEditor;

/// <summary>
/// Defines the basic contract for all command objects in the Command pattern.
/// This interface represents the Command abstraction that decouples
/// the invoker (UI elements, macros, etc.) from the receiver (document operations).
/// </summary>
/// <remarks>
/// <list type="bullet">
/// <item>Encapsulates a request as an object</item>
/// <item>Decouples invoker from receiver</item>
/// <item>Allows parameterization of clients with different requests</item>
/// <item>Enables queuing and logging of requests</item>
/// <item>Commands can be executed immediately or stored for later</item>
/// <item>Can be passed as parameters and stored in collections</item>
/// </list>
/// </remarks>
public interface ICommand
{
    /// <summary>
    /// Executes the command's operation.
    /// This method encapsulates the request and delegates the actual work
    /// to the appropriate receiver object.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item>Perform the intended operation by calling methods on receiver</item>
    /// <item>Handle any necessary state management</item>
    /// <item>For undoable commands, save state information before executing</item>
    /// <item>Add itself to history if it supports undo operations</item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// ICommand command = new ItalicCommand(document, history);
    /// command.Execute(); // Applies italic formatting and saves to history
    /// </code>
    /// </example>
    void Execute();
}