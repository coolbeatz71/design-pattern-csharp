namespace OopPrinciples.Composition;

public interface IWheel { void Rotate(); }

/// <summary>
/// Represents a wheel component of a car.
/// </summary>
/// <remarks>
/// Called within <see cref="Car"/> to simulate wheel rotation during startup.
/// </remarks>
public class Wheel : IWheel
{
    /// <summary>
    /// Rotates the wheel.
    /// </summary>
    public void Rotate()
    {
        Console.WriteLine("Wheels rotating");
    }
}

