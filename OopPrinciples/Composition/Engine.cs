namespace OopPrinciples.Composition;

/// <summary>
/// Represents an engine component of a car.
/// </summary>
/// <remarks>
/// Used by the <see cref="Car"/> class to demonstrate composition.
/// </remarks>
public class Engine
{
    /// <summary>
    /// Starts the engine.
    /// </summary>
    public void Start()
    {
        Console.WriteLine("Engine started");
    }
}

