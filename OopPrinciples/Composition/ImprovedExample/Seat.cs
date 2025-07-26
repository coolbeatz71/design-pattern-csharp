namespace OopPrinciples.Composition.ImprovedExample;

public interface ISeat { void Bend(); }

/// <summary>
/// Represents a seat inside a car.
/// </summary>
/// <remarks>
/// Composed in the <see cref="Car"/> class to show seat behavior.
/// </remarks>
public class Seat : ISeat
{
    /// <summary>
    /// Simulates bending the seat.
    /// </summary>
    public void Bend()
    {
        Console.WriteLine("Bend the seats");
    }
}

