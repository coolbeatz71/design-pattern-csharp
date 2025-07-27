namespace SolidPrinciples.LSP.GoodExample;

/// <summary>
/// Represents a rectangle shape with independently settable width and height.
/// </summary>
/// <remarks>
/// This class adheres to the Liskov Substitution Principle (LSP) by preserving the expected behavior
/// of the <see cref="Shape"/> abstraction. Clients using <see cref="Rectangle"/> through the base class
/// can safely manipulate width and height independently.
/// </remarks>
/// <example>
/// <code lang="c#">
/// Shape shape = new Rectangle { Width = 4, Height = 5 };
/// Console.WriteLine(shape.Area); // ✅ Outputs 20
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
    /// Gets the area of the rectangle.
    /// </summary>
    public override double Area => Width * Height;
}