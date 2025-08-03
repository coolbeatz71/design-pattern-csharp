namespace DesignPatterns.Behavioral.Strategy.GoodExample.Contracts;

/// <summary>
/// Strategy interface for compression behavior.
/// Allows different compression algorithms to be injected and executed at runtime.
/// </summary>
public interface ICompressor
{
    /// <summary>
    /// Executes the compression algorithm.
    /// </summary>
    void Compress(string fileName);
}