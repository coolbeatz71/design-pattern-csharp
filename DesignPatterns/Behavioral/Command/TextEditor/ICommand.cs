namespace DesignPatterns.Behavioral.Command.TextEditor;

/// <summary>
/// Defines the contract for all commands in the Command pattern implementation.
/// This interface enables encapsulation of requests as objects, allowing for parameterization
/// of clients with different requests, queuing of requests, and logging of requests.
/// It also provides support for undoable operations.
/// </summary>
/// <remarks>
/// this interface represents the Command abstraction that declares
/// a method for executing a command. All concrete commands implement this interface.
/// The Command pattern decouples the object that invokes the operation from the object
/// that performs the operation.
/// </remarks>
public interface ICommand
{
    /// <summary>
    /// Executes the command, performing the encapsulated operation.
    /// </summary>
    /// <remarks>
    /// This method encapsulates the actual operation logic. When called by the invoker,
    /// it delegates the work to the appropriate receiver object.
    /// </remarks>
    void Execute();
    
    /// <summary>
    /// Undoes the operation performed by the Execute method, restoring the previous state.
    /// </summary>
    /// <remarks>
    /// This method provides the reverse operation of Execute, enabling undo functionality.
    /// It's crucial for implementing features like undo/redo in applications.
    /// </remarks>
    void Undo();
}