using DesignPatterns.Behavioral.Strategy.GoodExample.Contracts;

namespace DesignPatterns.Behavioral.Strategy.GoodExample.Overlay;

/// <summary>
/// Null object overlay strategy: no overlay applied.
/// Avoids null checks by using a no-op implementation.
/// </summary>
public class NoOverlay : IOverlay
{
    /// <inheritdoc />    
    public void Apply(string fileName)
    {
        Console.WriteLine("Not applying an overlay");
    }
}