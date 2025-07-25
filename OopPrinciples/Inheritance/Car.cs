namespace OopPrinciples.Inheritance;

/// <summary>
/// Represents a car, which is a specific type of Vehicle.
/// <example>
/// <para>
/// This example shows how Car inherits from Vehicle and extends its functionality.
/// </para>
/// <code>
/// Car car = new Car
/// {
///     Brand = "Toyota",
///     Model = "Corolla",
///     Year = 2021,
///     NumberOfDoors = 4,
///     NumberOfWheels = 4
/// };
/// car.Start(); // Calls the Car's Start method
/// car.Stop();  // Inherited from Vehicle
/// </code>
/// </example>
/// </summary>
/// <remarks>
/// Inherits from the <see cref="Vehicle"/> class and adds properties specific to cars.
/// </remarks>
public class Car : Vehicle
{
    /// <summary>
    /// Gets or sets the number of doors on the car.
    /// </summary>
    public int NumberOfDoors { get; set; }

    /// <summary>
    /// Gets or sets the number of wheels on the car.
    /// </summary>
    public int NumberOfWheels { get; set; }

    /// <summary>
    /// Starts the car. This method hides the base class Start method.
    /// <list type="bullet">
    /// <item>
    ///     <description>The new keyword hides the base class method.</description>
    /// </item>
    /// <item>
    ///     <description>
    ///         The base method is still there, but you're saying: 
    ///         "When calling Start() on a Car instance (declared as Car), use this new version instead."
    ///     </description>
    /// </item>
    /// <item>
    ///     <description>
    ///         But if the object is referenced as the base type (Vehicle), the base class's Start() will be called.
    ///     </description>
    /// </item>
    /// </list>
    /// </summary>
    public new void Start()
    {
        Console.WriteLine("Car is starting.");
    }
}
