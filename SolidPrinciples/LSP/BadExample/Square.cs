namespace SolidPrinciples.LSP.BadExample;

/// <summary>
/// Represents a square shape, which is incorrectly modeled as a specialized rectangle.
/// </summary>
/// <remarks>
/// This class violates the Liskov Substitution Principle (LSP). Although a square
/// "is a" rectangle in geometric terms, it cannot be substituted for a rectangle in code
/// without breaking expectations. A rectangle allows width and height to vary independently,
/// but a square enforces them to be equal, causing incorrect behavior when used polymorphic-ally.
///
/// <para><b>Violation Example:</b></para>
/// <code>
/// void PrintArea(Rectangle rect)
/// {
///     rect.Width = 5;
///     rect.Height = 4;
///     Console.WriteLine(rect.Area); // Expected: 20
/// }
///
/// Shape shape = new Square();
/// PrintArea((Rectangle)shape); // Outputs 25 instead of 20!
/// </code>
/// </remarks>
public class Square : Rectangle
{
    /// <inheritdoc/>
    protected override double Width
    {
        get => base.Width;
        set => base.Width = base.Height = value; // Forces square behavior
    }

    /// <inheritdoc/>
    protected override double Height
    {
        get => base.Height;
        set => base.Width = base.Height = value; // Forces square behavior
    }
}