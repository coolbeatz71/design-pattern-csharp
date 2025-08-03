using DesignPatterns.Behavioral.Strategy.GoodExample.Contracts;

namespace DesignPatterns.Behavioral.Strategy.GoodExample.Overlay;

/// <summary>
/// Concrete overlay strategy: Blur effect.
/// </summary>
public class BlurOverlay: IOverlay
{
    /// <inheritdoc />
    public void Apply(string fileName)
    {
        Console.WriteLine("Applying blur overlay");
    }
}