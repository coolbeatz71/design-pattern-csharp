using DesignPatterns.Behavioral.Strategy.GoodExample.Contracts;

namespace DesignPatterns.Behavioral.Strategy.GoodExample.Compressor;

/// <summary>
/// Concrete compression strategy: WebM format.
/// </summary>
public class WebMCompressor: ICompressor
{
    /// <inheritdoc />
    public void Compress(string fileName)
    {
        Console.WriteLine("Compressing using WebM");
    }
}