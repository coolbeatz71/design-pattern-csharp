namespace OopPrinciples.Composition;

public interface IChassis { void Support(); }

/// <summary>
/// Represents the chassis component that supports the structure of a car.
/// </summary>
/// <remarks>
/// Used within the <see cref="Car"/> class to support the car.
/// </remarks>
public class Chassis : IChassis
{
    /// <summary>
    /// Supports the car structure.
    /// </summary>
    public void Support()
    {
        Console.WriteLine("Chassis supporting the car");
    }
}

