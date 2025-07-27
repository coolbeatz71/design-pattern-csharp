namespace SolidPrinciples.ISP.BadExample;

/// <summary>
/// Represents a 3D sphere shape that correctly uses both area and volume.
/// </summary>
public class Sphere : IShape
{
    public double Radius { get; set; }

    /// <inheritdoc/>
    public double Area()
    {
        return 4 * Math.PI * Math.Pow(Radius, 2);
    }

    /// <inheritdoc/>
    public double Volume()
    {
        return (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);
    }
}