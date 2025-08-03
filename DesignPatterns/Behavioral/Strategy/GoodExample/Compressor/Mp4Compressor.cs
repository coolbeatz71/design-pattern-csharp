using DesignPatterns.Behavioral.Strategy.GoodExample.Contracts;

namespace DesignPatterns.Behavioral.Strategy.GoodExample.Compressor;

/// <summary>
/// Concrete compression strategy: MP4 format.
/// </summary>
public class Mp4Compressor: ICompressor
{
    /// <inheritdoc />
    public void Compress(string fileName)
    {
        Console.WriteLine("Compressing using MP4");
    }
}