namespace DesignPatterns.Behavioral.Command.RemoteControl.GoodExample;

/// <summary>
/// Concrete command that turns off the light.
/// </summary>
/// <param name="light">The receiver of the request.</param>
/// <remarks>
/// Encapsulates the action to turn off a light and delegates it to the `Light` receiver.
///
/// <para><b>Command Role</b> Binds the receiver to the "TurnOff" action.</para>
///
/// <example>
/// <code>
/// var light = new Light();
/// var turnOffCommand = new TurnOffCommand(light);
/// var remote = new RemoteControl(turnOffCommand);
/// remote.PressButton(); // Output: "Light is off"
/// </code>
/// </example>
/// </remarks>
public class TurnOffCommand(Light light) : ICommand
{
    /// <inheritdoc />
    public void Execute()
    {
        light.TurnOff();
    }
}