namespace SolidPrinciples.DIP.BadExample;

/// <summary>
/// Represents a low-level engine component.
/// </summary>
public class Engine
{
    /// <summary>
    /// Starts the engine.
    /// </summary>
    public void Start()
    {
        Console.WriteLine("Engine started.");
    }
}