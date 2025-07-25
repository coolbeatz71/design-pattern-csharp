namespace OopPrinciples.Polymorphism;

/// <summary>
/// Represents a generic vehicle with basic properties and virtual behaviors.
/// </summary>
/// <remarks>
/// This base class defines shared properties and virtual methods for <c>Start</c> and <c>Stop</c>,
/// <para>allowing derived types to override and customize these behaviors.</para> 
/// 
/// This enables polymorphism, for example:
/// <code>
/// List&lt;Vehicle&gt; vehicles = new List&lt;Vehicle&gt;
/// {
///     new Car(),
///     new Plane(),
///     new MotorCycle()
/// };
///
/// foreach (var vehicle in vehicles)
/// {
///     vehicle.Start(); // Calls the appropriate overridden method at runtime
/// }
/// </code>
/// </remarks>
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
    /// Gets or sets the year the vehicle was manufactured.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Starts the vehicle. Can be overridden in derived classes.
    /// </summary>
    public virtual void Start()
    {
        Console.WriteLine("Vehicle is starting.");
    }

    /// <summary>
    /// Stops the vehicle. Can be overridden in derived classes.
    /// </summary>
    public virtual void Stop()
    {
        Console.WriteLine("Vehicle is stopping.");
    }
}
