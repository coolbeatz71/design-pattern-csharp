using DesignPatterns.Behavioral.Strategy.GoodExample.Contracts;

namespace DesignPatterns.Behavioral.Strategy.GoodExample.Compressor;

/// <summary>
/// Concrete compression strategy: MOV format.
/// </summary>
public class MovCompressor: ICompressor
{
    /// <inheritdoc />
    public void Compress(string fileName)
    {
        Console.WriteLine("Compressing using MOV");
    }
}