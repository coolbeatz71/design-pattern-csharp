namespace OopPrinciples.Polymorphism;

/// <summary>
/// Represents a plane, inheriting from <see cref="Vehicle"/>.
/// </summary>
/// <remarks>
/// Overrides <c>Start</c> and <c>Stop</c> with behavior specific to aircraft.
/// <para>Enables polymorphic use through the base <see cref="Vehicle"/> type.</para>
/// </remarks>
public class Plane : Vehicle
{
    /// <summary>
    /// Gets or sets the number of doors on the plane.
    /// </summary>
    public int NumberOfDoors { get; set; }

    /// <inheritdoc />
    public override void Start()
    {
        Console.WriteLine("Plane is starting.");
    }

    /// <inheritdoc />
    public override void Stop()
    {
        Console.WriteLine("Plane is stopping.");
    }
}
