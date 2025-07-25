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
    private Engine engine = new Engine();
    private Wheel wheel = new Wheel();
    private Chassis chassis = new Chassis();
    private Seat seat = new Seat();

    /// <summary>
    /// Starts the car by delegating behavior to its internal components.
    /// </summary>
    public void Start()
    {
        engine.Start();
        wheel.Rotate();
        chassis.Support();
        seat.Bend();
        Console.WriteLine("Car started");
    }
}
