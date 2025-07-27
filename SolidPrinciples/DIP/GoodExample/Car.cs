namespace SolidPrinciples.DIP.GoodExample;

/// <summary>
/// Represents a car that depends on an abstract engine interface.
/// </summary>
/// <remarks>
/// ✅ <b>Follows the Dependency Inversion Principle (DIP):</b>
///
/// <para>
/// The <see cref="Car"/> class no longer depends on a concrete <c>Engine</c> type. 
/// Instead, it relies on the <see cref="IEngine"/> abstraction, which is injected via the constructor.
/// </para>
///
/// <para>
/// This design allows for:
/// <list type="bullet">
///   <item><description>Easy substitution of different engine types (e.g., electric, mock for testing).</description></item>
///   <item><description>Improved maintainability and testability.</description></item>
///   <item><description>Looser coupling between modules.</description></item>
/// </list>
/// </para>
///
/// <para>
/// <b>Example:</b>
/// <code>
/// var engine = new Engine();
/// var car = new Car(engine);
/// car.Start();
/// </code>
/// </para>
/// </remarks>
public class Car(IEngine engine)
{
    /// <summary>
    /// Starts the car by delegating to the engine.
    /// </summary>
    public void Start()
    {
        engine.Start();
        Console.WriteLine("Car started");
    }
}