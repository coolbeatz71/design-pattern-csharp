using SolidPrinciples.DIP.BadExample;

namespace SolidPrinciples.DIP.GoodExample;

/// <summary>
/// Abstraction for engine behavior.
/// </summary>
/// <remarks>
/// This interface allows high-level modules (e.g., <see cref="Car"/>)
/// to depend on abstractions rather than concrete implementations.
/// </remarks>
public interface IEngine
{
    /// <summary>
    /// Starts the engine.
    /// </summary>
    void Start();
}