namespace SolidPrinciples.DIP.GoodExample;

/// <summary>
/// A concrete implementation of <see cref="IEngine"/> that represents a gasoline engine.
/// </summary>
public class Engine : IEngine
{
    /// <inheritdoc />
    public void Start()
    {
        Console.WriteLine("Engine started.");
    }
}