namespace OopPrinciples.Composition;

namespace OopPrinciples.Composition;

/// <summary>
/// Represents a car composed of engine, wheels, chassis, and seat components.
/// Demonstrates composition via dependency injection using a primary constructor.
/// </summary>
/// <param name="engine">Engine component of the car.</param>
/// <param name="wheel">Wheel component of the car.</param>
/// <param name="chassis">Chassis component of the car.</param>
/// <param name="seat">Seat component of the car.</param>
/// <example>
/// Example usage:
/// <code>
/// var car = new Car(
///     new SportEngine(),
///     new AlloyWheel(),
///     new SteelChassis(),
///     new LeatherSeat()
/// );
/// 
/// car.Start();
/// </code>
/// </example>
public class Car(IEngine engine, IWheel wheel, IChassis chassis, ISeat seat)
{
    private readonly IEngine engine = engine;
    private readonly IWheel wheel = wheel;
    private readonly IChassis chassis = chassis;
    private readonly ISeat seat = seat;

    /// <summary>
    /// Starts the car by delegating the start behavior to its composed components.
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


