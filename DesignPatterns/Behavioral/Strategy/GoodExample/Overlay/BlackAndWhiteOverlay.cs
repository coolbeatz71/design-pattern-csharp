using DesignPatterns.Behavioral.Strategy.GoodExample.Contracts;

namespace DesignPatterns.Behavioral.Strategy.GoodExample.Overlay;

/// <summary>
/// Concrete overlay strategy: Black and white effect.
/// </summary>
public class BlackAndWhiteOverlay: IOverlay
{
    /// <inheritdoc />
    public void Apply(string fileName)
    {
        Console.WriteLine("Applying black and white overlay");
    }
}