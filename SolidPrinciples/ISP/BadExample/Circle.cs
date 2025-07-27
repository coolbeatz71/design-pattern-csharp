namespace SolidPrinciples.ISP.BadExample;

/// <summary>
/// Represents a 2D circle shape.
/// 
/// <para>
/// ❌ This class is forced to implement <see cref="IShape.Volume"/> even though
/// it is a 2D shape and has no concept of volume. This leads to a thrown exception
/// at runtime, which is a clear violation of ISP.
/// </para>
/// </summary>
public class Circle : IShape
{
    public double Radius { get; set; }

    /// <inheritdoc/>
    public double Area()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }

    /// <inheritdoc/>
    public double Volume()
    {
        throw new InvalidOperationException("Volume not applicable for 2D shapes.");
    }
}