namespace DesignPatterns.Behavioral.Command.RemoteControl.BadExample;

/// <summary>
/// Represents a basic light with operations to turn on, turn off, or dim the brightness.
/// </summary>
/// <remarks>
/// This class is responsible only for executing lighting-related actions.
/// It encapsulates the actual behavior that the remote is trying to control.
/// </remarks>
public class Light
{
    /// <summary>
    /// Turns on the light.
    /// </summary>
    public void TurnOn()
    {
        Console.WriteLine("Turning on light");
    }

    /// <summary>
    /// Turns off the light.
    /// </summary>
    public void TurnOff()
    {
        Console.WriteLine("Turning off light");
    }

    /// <summary>
    /// Dims the light.
    /// </summary>
    public void Dim()
    {
        Console.WriteLine("Dim light");
    }
}