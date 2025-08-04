namespace DesignPatterns.Behavioral.Command.RemoteControl.GoodExample;

/// <summary>
/// Concrete command that dims the light.
/// </summary>
/// <param name="light">The receiver of the request.</param>
/// <remarks>
/// Encapsulates the action to dim the light and delegates it to the `Light` receiver.
///
/// <para><b>Command Role</b> Binds the receiver to the "Dim" action.</para>
///
/// <example>
/// <code>
/// var light = new Light();
/// var dimCommand = new DimCommand(light);
/// var remote = new RemoteControl(dimCommand);
/// remote.PressButton(); // Output: "Light is dim"
/// </code>
/// </example>
/// </remarks>
public class DimCommand(Light light) : ICommand
{
    /// <inheritdoc />
    public void Execute()
    {
        light.Dim();
    }
}