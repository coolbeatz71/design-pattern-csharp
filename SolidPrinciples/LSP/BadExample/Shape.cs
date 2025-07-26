namespace SolidPrinciples.LSP.BadExample;

/// <summary>
/// Represents a geometric shape with an area.
/// </summary>
/// <remarks>
/// This base class is intended to follow the Liskov Substitution Principle (LSP),
/// which states that derived classes should be substitutable for their base classes
/// without altering the correctness of the program.
/// </remarks>
/// <example>
/// <code>
/// Shape shape = new Rectangle { Width = 5, Height = 4 };
/// double area = shape.Area; // OK
/// </code>
/// </example>
public abstract class Shape
{
    /// <summary>
    /// Gets the area of the shape.
    /// </summary>
    public abstract double Area { get; }
}