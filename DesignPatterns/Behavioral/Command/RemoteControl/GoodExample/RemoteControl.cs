namespace DesignPatterns.Behavioral.Command.RemoteControl.GoodExample;

/// <summary>
/// Invoker class that executes commands.
/// </summary>
/// <param name="command">The initial command to execute when the button is pressed.</param>
/// <remarks>
/// This class is unaware of the actual logic behind the command—it just knows it must call `Execute()`.
/// This decouples the invoker from both the receiver and the action logic.
///
/// <para><b>Invoker Role:</b> Triggers the execution of a command.</para>
///
/// <example>
/// <code>
/// var light = new Light();
/// var onCommand = new TurnOnCommand(light);
/// var offCommand = new TurnOffCommand(light);
/// var remote = new RemoteControl(onCommand);
/// 
/// remote.PressButton(); // Output: "Light is on"
/// 
/// remote.SetCommand(offCommand);
/// remote.PressButton(); // Output: "Light is off"
/// </code>
/// </example>
/// </remarks>
public class RemoteControl(ICommand command)
{
    private ICommand _command = command;

    /// <summary>
    /// Sets the command to be executed.
    /// </summary>
    /// <param name="newCommand">New command to be assigned.</param>
    public void SetCommand(ICommand newCommand)
    {
        _command = newCommand;
    }

    /// <summary>
    /// Executes the currently assigned command.
    /// </summary>
    public void PressButton()
    {
        _command.Execute();
    }
}