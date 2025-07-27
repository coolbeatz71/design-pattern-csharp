namespace SolidPrinciples.LSP.GoodExample;

/// <summary>
/// Represents a square shape where all sides are equal.
/// </summary>
/// <remarks>
/// This class also adheres to the Liskov Substitution Principle (LSP) by not inheriting from <see cref="Rectangle"/>,
/// but instead directly from <see cref="Shape"/>. This avoids the pitfall of tightly coupling square behavior
/// to the mutable dimensions of a rectangle.
/// </remarks>
/// <example>
/// <code lang="c#">
/// Shape shape = new Square { Length = 5 };
/// Console.WriteLine(shape.Area); // ✅ Outputs 25
/// </code>
/// </example>
public class Square : Shape
{
    /// <summary>
    /// Gets or sets the length of the sides of the square.
    /// </summary>
    public double Length { get; set; }

    /// <summary>
    /// Gets the area of the square.
    /// </summary>
    public override double Area => Length * Length;
}