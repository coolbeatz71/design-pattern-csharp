namespace DesignPatterns.Behavioral.Command.RemoteControl.GoodExample;

/// <summary>
/// Receiver class that knows how to perform actual operations (turn on/off/dim).
/// It contains the implementation in details of the real actions/operations.
/// </summary>
/// <remarks>
/// This class represents the actual business logic and remains decoupled from how the command is triggered.
/// 
/// <para><b>Receiver Role:</b> Performs the actual work requested by a command.</para>
/// </remarks>
public class Light
{
    /// <summary>
    /// Turns the light on.
    /// </summary>
    public void TurnOn()
    {
        Console.WriteLine("Light is on");
    }

    /// <summary>
    /// Turns the light off.
    /// </summary>
    public void TurnOff()
    {
        Console.WriteLine("Light is off");
    }

    /// <summary>
    /// Dims the light.
    /// </summary>
    public void Dim()
    {
        Console.WriteLine("Light is dim");
    }
}