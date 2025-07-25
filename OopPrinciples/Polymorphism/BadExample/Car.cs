namespace OopPrinciples.Polymorphism.BadExample;

/// <summary>
/// Represents a car with brand, model, year, and number of doors.
/// </summary>
/// <remarks>
/// This class, like <see cref="MotorCycle"/>, violates polymorphism by not abstracting shared vehicle behaviors. 
/// The <c>Start</c> and <c>Stop</c> methods are duplicated rather than being part of an abstract superclass or interface,
/// making the system harder to extend and maintain.
/// </remarks>
public class Car
{
    /// <summary>
    /// Gets or sets the brand of the car.
    /// </summary>
    public string Brand { get; set; }

    /// <summary>
    /// Gets or sets the model of the car.
    /// </summary>
    public string Model { get; set; }

    /// <summary>
    /// Gets or sets the year the car was manufactured.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Gets or sets the number of doors on the car.
    /// </summary>
    public int NumberOfDoors { get; set; }

    /// <summary>
    /// Starts the car.
    /// </summary>
    public void Start()
    {
        Console.WriteLine("Car is starting.");
    }

    /// <summary>
    /// Stops the car.
    /// </summary>
    public void Stop()
    {
        Console.WriteLine("Car is stopping.");
    }
}
