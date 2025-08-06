namespace DesignPatterns.Behavioral.Command.RemoteControl.GoodExample;

/// <summary>
/// Defines a command interface with an Execute operation.
/// </summary>
/// <remarks>
/// This is the base abstraction in the Command Pattern. All concrete commands implement this interface,
/// enabling polymorphic execution of commands.
///
/// <para><b>Command Role:</b> Declares the interface for executing operations.</para>
/// </remarks>
public interface ICommand
{
    /// <summary>
    /// Executes the encapsulated action.
    /// </summary>
    void Execute();
}