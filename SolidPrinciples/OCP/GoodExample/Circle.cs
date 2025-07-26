namespace SolidPrinciples.OCP.GoodExample;

/// <summary>
/// Represents a circle shape.
/// <para>
/// This class extends <see cref="Shape"/> and overrides <see cref="CalculateArea"/> using the formula πr².
/// </para>
/// </summary>
/// <example>
/// <code>
/// var circle = new Circle { Radius = 3 };
/// double area = circle.CalculateArea();
/// </code>
/// </example>
public class Circle : Shape
{
    /// <summary>
    /// Gets or sets the radius of the circle.
    /// </summary>
    public double Radius { get; set; }

    /// <summary>
    /// Calculates the area of the circle using π * r².
    /// </summary>
    /// <returns>The area of the circle.</returns>
    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}
