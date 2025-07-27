namespace SolidPrinciples.LSP.GoodExample;

/// <summary>
/// Represents a geometric shape.
/// </summary>
/// <remarks>
/// This base class defines the contract for all shape types via an abstract <see cref="Area"/> property.
/// All subclasses can be safely substituted for this base class, adhering to the Liskov Substitution Principle (LSP).
/// </remarks>
/// <example>
/// <code lang="c#">
/// Shape shape = new Rectangle { Width = 4, Height = 5 };
/// Console.WriteLine(shape.Area); // ✅ Outputs 20
///
/// shape = new Square { Length = 5 };
/// Console.WriteLine(shape.Area); // ✅ Outputs 25
/// </code>
/// </example>
public abstract class Shape
{
    /// <summary>
    /// Gets the area of the shape.
    /// </summary>
    public abstract double Area { get; }
}