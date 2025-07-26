namespace SolidPrinciples.OCP.GoodExample;

/// <summary>
/// Represents a geometric shape.
/// <para>
/// This abstract base class supports the Open/Closed Principle (OCP) from SOLID principles.
/// <para>
/// It is <b>closed for modification</b> because the base class does not need to change
/// when new shapes are introduced. It is <b>open for extension</b> because new shapes
/// can inherit from this class and provide their own implementation of <see cref="CalculateArea"/>.
/// </para>
/// </para>
/// </summary>
/// <example>
/// <code>
/// Shape rectangle = new Rectangle { Width = 10, Height = 5 };
/// double area = rectangle.CalculateArea();
/// </code>
/// </example>
public abstract class Shape
{
    /// <summary>
    /// Calculates the area of the shape.
    /// <para>
    /// This method must be overridden by subclasses to provide shape-specific area calculations.
    /// </para>
    /// </summary>
    /// <returns>The calculated area of the shape.</returns>
    public abstract double CalculateArea();
}
