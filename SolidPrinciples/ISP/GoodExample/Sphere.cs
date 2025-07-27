namespace SolidPrinciples.ISP.GoodExample;


/// <summary>
/// Represents a 3D spherical shape.
/// Implements <see cref="IShape3D"/> because it supports both surface area and volume calculations.
/// This respects ISP by using a contract tailored to 3D shapes.
/// </summary>
public class Sphere : IShape3D
{
    /// <summary>
    /// Gets or sets the radius of the sphere.
    /// </summary>
    private double Radius { get; set; }

    /// <summary>
    /// Calculates the surface area of the sphere using the formula: 4 × π × r².
    /// </summary>
    /// <returns>The surface area of the sphere.</returns>
    public double Area()
    {
        return 4 * Math.PI * Math.Pow(Radius, 2);
    }

    /// <summary>
    /// Calculates the volume of the sphere using the formula: (4/3) × π × r³.
    /// </summary>
    /// <returns>The volume of the sphere.</returns>
    public double Volume()
    {
        return (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);
    }
}