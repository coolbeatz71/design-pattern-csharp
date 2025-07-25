namespace OopPrinciples.Composition;

/// <summary>
/// Represents a wheel component of a car.
/// </summary>
/// <remarks>
/// Called within <see cref="Car"/> to simulate wheel rotation during startup.
/// </remarks>
public class Wheel
{
    /// <summary>
    /// Rotates the wheel.
    /// </summary>
    public void Rotate()
    {
        Console.WriteLine("Wheels rotating");
    }
}
