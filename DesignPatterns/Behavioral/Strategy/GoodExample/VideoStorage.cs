using DesignPatterns.Behavioral.Strategy.GoodExample.Contracts;
using DesignPatterns.Behavioral.Strategy.GoodExample.Overlay;

namespace DesignPatterns.Behavioral.Strategy.GoodExample;

/// <summary>
/// Context class that stores videos using defined compression and overlay strategies.
/// </summary>
/// <remarks>
/// This class demonstrates a proper use of the <b>Strategy Pattern</b>, offering the following benefits:
/// <list type="bullet">
///   <item>
///     <description>
///     ✅ <b>Open/Closed Principle</b> – New compressors or overlays can be added without modifying <c>VideoStorage</c>.
///     </description>
///   </item>
///   <item>
///     <description>
///     ✅ <b>Single Responsibility Principle</b> – <c>VideoStorage</c> only coordinates behavior, not implement it.
///     </description>
///   </item>
///   <item>
///     <description>
///     ✅ <b>Testable and maintainable</b> – Compression and overlay strategies can be tested independently.
///     </description>
///   </item>
/// </list>
///
/// <para><b>Example usage:</b></para>
/// <code>
/// var storage = new VideoStorage(new Mp4Compressor(), new BlurOverlay());
/// storage.Store("video.mp4");
///
/// var storage = new VideoStorage(new MovCompressor(), new NoOverlay());
/// storage.Store("video.mov");
/// </code>
/// </remarks>
public class VideoStorage(ICompressor compressor, IOverlay? overlay = null)
{
    private ICompressor _compressor = compressor;
    private IOverlay _overlay = overlay ?? new NoOverlay();

    /// <summary>
    /// Changes the compression strategy.
    /// </summary>
    /// <param name="compressor">New compression strategy.</param>
    public void SetCompressor(ICompressor compressor)
    {
        _compressor = compressor;
    }
    
    /// <summary>
    /// Changes the overlay strategy.
    /// </summary>
    /// <param name="overlay">New overlay strategy.</param>
    public void SetOverlay(IOverlay overlay)
    {
        _overlay = overlay;
    }
    
    /// <summary>
    /// Stores the video file by compressing and applying an overlay.
    /// </summary>
    /// <param name="fileName">The video file to store.</param>
    public void Store(string fileName)
    {
        _compressor.Compress(fileName);
        _overlay.Apply(fileName);
        Console.WriteLine("Storing video to " + fileName);
    }
}