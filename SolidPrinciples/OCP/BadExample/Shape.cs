namespace SolidPrinciples.OCP.BadExample;

/// <summary>
/// Represents a geometric shape and calculates its area based on its type.
/// </summary>
/// <remarks>
/// <para>
/// ❌ <b>OCP Violation:</b> This class violates the <i>Open-Closed Principle</i> (OCP), which states that:
/// <b>software entities (classes, modules, functions, etc.) should be open for extension but closed for modification</b>.
/// </para>
/// <para>
/// In this example, if we want to support a new shape (e.g., <c>Triangle</c>, ), 
/// we must add more class fields, modify the <see cref="CalculateArea"/> method
/// and the <see cref="ShapeType"/> enum. 
/// This is risky, especially in large systems, as it introduces bugs and breaks existing behavior.
/// </para>
/// <para>
/// ✅ A better approach is to use polymorphism by creating a base class or interface like <c>IShape</c> and implementing a separate
/// class for each shape (e.g., <c>Circle</c>, <c>Rectangle</c>). 
/// Each shape class should encapsulate its own area calculation logic.
/// </para>
/// </remarks>
public class Shape
{
    public double Width { get; set; }
    public double Length { get; set; }
    public double Radius { get; set; }
    public ShapeType Type { get; set; }

    public double CalculateArea()
    {
        return Type switch
        {
            ShapeType.Rectangle => Length * Width,
            ShapeType.Circle => Math.PI * Math.Pow(Radius, 2),
            _ => throw new InvalidOperationException("Unsupported shape type."),
        };
    }
}
