namespace SolidPrinciples.ISP.GoodExample;

/// <summary>
/// Represents a 2D circle shape.
/// Implements <see cref="IShape2D"/> since a circle only requires area calculation.
/// This demonstrates ISP by not forcing Circle to implement 3D-specific logic like Volume().
/// </summary>
public class Circle : IShape2D
{
    /// <summary>
    /// Gets or sets the radius of the circle.
    /// </summary>
    private double Radius { get; set; }

    /// <summary>
    /// Calculates the area of the circle using the formula: π × r².
    /// </summary>
    /// <returns>The area of the circle.</returns>
    public double Area()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}