namespace OopPrinciples.Inheritance;

/// <summary>
/// Represents a bike, which is a specific type of Vehicle.
/// <example>
/// <para>
/// This example shows how Bike inherits common properties and methods from Vehicle.
/// </para>
/// <code>
/// Bike bike = new Bike
/// {
///     Brand = "Yamaha",
///     Model = "MT-07",
///     Year = 2022,
///     NumberOfWheels = 2
/// };
/// bike.Start(); // Inherited from Vehicle
/// bike.Stop();  // Inherited from Vehicle
/// </code>
/// </example>
/// </summary>
/// <remarks>
/// Inherits from the <see cref="Vehicle"/> class and adds bike-specific properties.
/// </remarks>
public class Bike : Vehicle
{
    /// <summary>
    /// Gets or sets the number of wheels on the bike.
    /// </summary>
    public int NumberOfWheels { get; set; }
}
