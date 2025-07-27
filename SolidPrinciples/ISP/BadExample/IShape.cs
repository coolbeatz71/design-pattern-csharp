namespace SolidPrinciples.ISP.BadExample;

/// <summary>
/// Represents a shape with both area and volume.
/// 
/// <para>
/// ❌ This interface violates the Interface Segregation Principle (ISP) because it forces
/// all implementers to define both <see cref="Area"/> and <see cref="Volume"/>, even if one
/// of them doesn't make sense (e.g., 2D shapes don't have volume).
/// </para>
/// </summary>
public interface IShape
{
    /// <summary>
    /// Calculates the area of the shape.
    /// </summary>
    double Area();

    /// <summary>
    /// Calculates the volume of the shape.
    /// 
    /// <para>❌ Problematic for 2D shapes which do not have a volume.</para>
    /// </summary>
    double Volume();
}