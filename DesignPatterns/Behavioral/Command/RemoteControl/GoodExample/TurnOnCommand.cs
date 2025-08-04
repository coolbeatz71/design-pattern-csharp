namespace DesignPatterns.Behavioral.Command.RemoteControl.GoodExample;

/// <summary>
/// Concrete command that turns on the light.
/// </summary>
/// <param name="light">The receiver of the request.</param>
/// <remarks>
/// This class encapsulates the request to turn on a light and delegates it to the receiver (`Light`).
///
/// <para><b>Command Role</b> Binds the receiver to the "TurnOn" action.</para>
///
/// <example>
/// <code>
/// var light = new Light();
/// var turnOnCommand = new TurnOnCommand(light);
/// var remote = new RemoteControl(turnOnCommand);
/// remote.PressButton(); // Output: "Light is on"
/// </code>
/// </example>
/// </remarks>
public class TurnOnCommand(Light light) : ICommand
{
    /// <inheritdoc />
    public void Execute()
    {
        light.TurnOn();
    }
}