namespace OopPrinciples.Composition;

/// <summary>
/// Represents a car composed of several components like engine, wheel, chassis, and seat.
/// </summary>
/// <remarks>
/// This class demonstrates <b>composition</b> by including other objects as fields and delegating behavior to them.
/// 
/// <para>Composition is a "has-a" relationship:</para>
/// <list type="bullet">
/// <item>Car <b>has an</b> Engine</item>
/// <item>Car <b>has a</b> Wheel</item>
/// <item>Car <b>has a</b> Chassis</item>
/// <item>Car <b>has a</b> Seat</item>
/// </list>
///
/// Example usage:
/// <example>
/// <code>
/// Car car = new Car();
/// car.Start();
/// // Output:
/// // Engine started
/// // Wheels rotating
/// // Chassis supporting the car
/// // Bend the seats
/// // Car started
/// </code>
/// </example>
/// </remarks>
public class Car
{
    private readonly Engine _engine = new Engine();
    private readonly Wheel _wheel = new Wheel();
    private readonly Chassis _chassis = new Chassis();
    private readonly Seat _seat = new Seat();

    /// <summary>
    /// Starts the car by delegating behavior to its internal components.
    /// </summary>
    public void Start()
    {
        _engine.Start();
        _wheel.Rotate();
        _chassis.Support();
        _seat.Bend();
        Console.WriteLine("Car started");
    }
}
