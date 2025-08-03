namespace DesignPatterns.Behavioral.Strategy.BadExample;

/// <remarks>
/// This class demonstrates a <b>poor implementation</b> of the Strategy Pattern. It uses enums and `if-else` logic
/// to decide which compression and overlay strategies to apply. This leads to multiple design issues:
///
/// <list type="bullet">
///   <item>
///     <description><b>❌ Violates Open/Closed Principle</b> – Every time you add a new compressor or overlay,
///     you must modify this class, making it fragile and not extensible.</description>
///   </item>
///   <item>
///     <description><b>❌ Violates Single Responsibility Principle</b> – The class handles multiple concerns:
///     storage logic, compression selection, and overlay application.</description>
///   </item>
///   <item>
///     <description><b>❌ Poor testability and maintainability</b> – Logic is hardcoded and scattered,
///     which makes unit testing and future refactoring difficult.</description>
///   </item>
///   <item>
///     <description><b>✅ Better approach</b> – Use proper Strategy interfaces for compression and overlay behaviors,
///     so each concern is encapsulated and extendable independently.</description>
///   </item>
/// </list>
/// </remarks>
public class VideoStorage
{
    private Compressor _compressor;
    private Overlay _overlay;

    /// <summary>
    /// Initializes a new instance of <see cref="VideoStorage"/> with a compressor and an optional overlay.
    /// </summary>
    /// <param name="compressor">The compression strategy to use (as enum, which is problematic).</param>
    /// <param name="overlay">The overlay strategy to use (as enum, also problematic). Defaults to None.</param>
    public VideoStorage(Compressor compressor, Overlay overlay = Overlay.None)
    {
        _compressor = compressor;
        _overlay = overlay;
    }

    /// <summary>
    /// Sets the compression method.
    /// </summary>
    /// <param name="compressor">The compression algorithm to apply (enum-based).</param>
    public void SetCompressor(Compressor compressor)
    {
        _compressor = compressor;
    }

    /// <summary>
    /// Sets the overlay type.
    /// </summary>
    /// <param name="overlay">The overlay effect to apply (enum-based).</param>
    public void SetOverlay(Overlay overlay)
    {
        _overlay = overlay;
    }

    /// <summary>
    /// Compresses the video, applies an overlay (if any), and stores it to the specified file.
    /// </summary>
    /// <param name="fileName">The output file name where the video is stored.</param>
    public void Store(string fileName)
    {
        // Compression logic is hardcoded and tied to enum values
        if (_compressor == Compressor.Mov)
        {
            Console.WriteLine("Compressing using MOV");
        }
        else if (_compressor == Compressor.Mp4)
        {
            Console.WriteLine("Compressing using MP4");
        }
        else if (_compressor == Compressor.WebM)
        {
            Console.WriteLine("Compressing using WEBM");
        }

        // Overlay logic is also hardcoded and non-extensible
        if (_overlay == Overlay.BlackAndWhite)
        {
            Console.WriteLine("Applying black and white overlay");
        }
        else if (_overlay == Overlay.Blur)
        {
            Console.WriteLine("Applying blur overlay");
        }
        else if (_overlay == Overlay.None)
        {
            Console.WriteLine("Not applying an overlay");
        }

        Console.WriteLine("Storing video to " + fileName);
    }
}