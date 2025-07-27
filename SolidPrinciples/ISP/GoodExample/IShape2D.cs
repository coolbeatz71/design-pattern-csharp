namespace SolidPrinciples.ISP.GoodExample;

/// <summary>
/// Represents a 2D shape.
/// This interface adheres to the Interface Segregation Principle (ISP) by exposing only
/// the operations relevant to 2D shapes, avoiding unnecessary method requirements.
/// </summary>
public interface IShape2D
{
    /// <summary>
    /// Calculates the area of a 2D shape.
    /// </summary>
    /// <returns>The area of the shape.</returns>
    double Area();
}