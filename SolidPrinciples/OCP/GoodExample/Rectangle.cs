namespace SolidPrinciples.OCP.GoodExample;

/// <summary>
/// Represents a rectangle shape.
/// <para>
/// This class extends <see cref="Shape"/> without modifying it,
/// thus respecting the Open/Closed Principle.
/// </para>
/// </summary>
/// <example>
/// <code>
/// var rectangle = new Rectangle { Width = 4, Height = 5 };
/// double area = rectangle.CalculateArea();
/// </code>
/// </example>
public class Rectangle : Shape
{
    /// <summary>
    /// Gets or sets the width of the rectangle.
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// Gets or sets the height of the rectangle.
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// Calculates the area of the rectangle using width × height.
    /// </summary>
    /// <returns>The area of the rectangle.</returns>
    public override double CalculateArea()
    {
        return Width * Height;
    }
}
