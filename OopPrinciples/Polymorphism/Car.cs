namespace OopPrinciples.Polymorphism;

/// <summary>
/// Represents a car, inheriting from <see cref="Vehicle"/>.
/// </summary>
/// <remarks>
/// Overrides <c>Start</c> and <c>Stop</c> methods to provide car-specific behavior.
/// <para>Demonstrates runtime polymorphism via base class references:</para>
/// <code>
/// Vehicle myVehicle = new Car();
/// myVehicle.Start(); // Outputs "Car is starting."
/// </code>
/// </remarks>
public class Car : Vehicle
{
    /// <summary>
    /// Gets or sets the number of doors on the car.
    /// </summary>
    public int NumberOfDoors { get; set; }

    /// <inheritdoc />
    public override void Start()
    {
        Console.WriteLine("Car is starting.");
    }

    /// <inheritdoc />
    public override void Stop()
    {
        Console.WriteLine("Car is stopping.");
    }
}
