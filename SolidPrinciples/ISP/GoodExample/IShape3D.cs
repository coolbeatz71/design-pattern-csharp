namespace SolidPrinciples.ISP.GoodExample;

/// <summary>
/// Represents a 3D shape.
/// This interface follows ISP by combining only the operations meaningful for 3D shapes.
/// 2D shapes are not burdened with implementing unnecessary methods like Volume().
/// </summary>
public interface IShape3D
{
    /// <summary>
    /// Calculates the surface area of a 3D shape.
    /// </summary>
    /// <returns>The surface area of the shape.</returns>
    double Area();

    /// <summary>
    /// Calculates the volume of a 3D shape.
    /// </summary>
    /// <returns>The volume of the shape.</returns>
    double Volume();
}