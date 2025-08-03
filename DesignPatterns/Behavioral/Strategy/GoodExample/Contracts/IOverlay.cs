namespace DesignPatterns.Behavioral.Strategy.GoodExample.Contracts;

/// <summary>
/// Strategy interface for overlay behavior.
/// Allows different overlay effects to be applied at runtime.
/// </summary>
public interface IOverlay
{
    /// <summary>
    /// Applies the overlay effect.
    /// </summary>
    void Apply(string fileName);
}