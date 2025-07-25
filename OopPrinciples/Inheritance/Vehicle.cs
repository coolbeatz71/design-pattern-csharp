namespace OopPrinciples.Inheritance;

/// <summary>
/// Represents a general vehicle with basic properties and actions.
/// <example>
/// <para>
/// This example shows how the Vehicle class can be used directly or inherited by other classes.
/// </para>
/// <code>
/// Vehicle vehicle = new Vehicle
/// {
///     Brand = "Generic",
///     Model = "ModelX",
///     Year = 2020
/// };
/// vehicle.Start();
/// vehicle.Stop();
/// </code>
/// </example>
/// </summary>
public class Vehicle
{
    /// <summary>
    /// Gets or sets the brand of the vehicle.
    /// </summary>
    public string Brand { get; set; }

    /// <summary>
    /// Gets or sets the model of the vehicle.
    /// </summary>
    public string Model { get; set; }

    /// <summary>
    /// Gets or sets the manufacturing year of the vehicle.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Starts the vehicle.
    /// </summary>
    public void Start()
    {
        Console.WriteLine("Vehicle is starting.");
    }

    /// <summary>
    /// Stops the vehicle.
    /// </summary>
    public void Stop()
    {
        Console.WriteLine("Vehicle is stopping.");
    }
}
