namespace SolidPrinciples.LSP.BadExample;

/// <summary>
/// Represents a rectangle with a specific width and height.
/// </summary>
/// <remarks>
/// This class adheres to the expected behavior of a rectangle,
/// allowing independent control of width and height.
/// </remarks>
/// <example>
/// <code>
/// Rectangle rect = new Rectangle();
/// rect.Width = 5;
/// rect.Height = 4;
/// double area = rect.Area; // 20
/// </code>
/// </example>
public class Rectangle : Shape
{
    /// <summary>
    /// Gets or sets the width of the rectangle.
    /// </summary>
    protected virtual double Width { get; set; }

    /// <summary>
    /// Gets or sets the height of the rectangle.
    /// </summary>
    protected virtual double Height { get; set; }

    /// <inheritdoc/>
    public override double Area => Width * Height;
}