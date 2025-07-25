namespace OopPrinciples.Polymorphism.BadExample;

/// <summary>
/// Represents a motorcycle with brand, model, and year information.
/// </summary>
/// <remarks>
/// This class violates the polymorphic principle because it does not inherit from a common base type or interface
/// that defines shared behavior like <c>Start</c> or <c>Stop</c>. This prevents treating different vehicle types uniformly
/// and leads to duplicated code in similar classes (e.g., <see cref="Car"/>).
/// </remarks>
public class MotorCycle
{
    /// <summary>
    /// Gets or sets the brand of the motorcycle.
    /// </summary>
    public string Brand { get; set; }

    /// <summary>
    /// Gets or sets the model of the motorcycle.
    /// </summary>
    public string Model { get; set; }

    /// <summary>
    /// Gets or sets the year the motorcycle was manufactured.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Starts the motorcycle.
    /// </summary>
    public void Start()
    {
        Console.WriteLine("Motorcycle is starting.");
    }

    /// <summary>
    /// Stops the motorcycle.
    /// </summary>
    public void Stop()
    {
        Console.WriteLine("Motorcycle is stopping.");
    }
}


