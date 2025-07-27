namespace OopPrinciples.Composition.ImprovedExample;

public interface IEngine { void Start(); }

/// <summary>
/// Represents an engine component of a car.
/// </summary>
/// <remarks>
/// Used by the <see cref="Car"/> class to demonstrate composition.
/// </remarks>
public class Engine : IEngine
{
    /// <summary>
    /// Starts the engine.
    /// </summary>
    public void Start()
    {
        Console.WriteLine("Engine started");
    }
}

