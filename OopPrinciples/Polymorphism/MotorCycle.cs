namespace OopPrinciples.Polymorphism;

/// <summary>
/// Represents a motorcycle, inheriting from <see cref="Vehicle"/>.
/// </summary>
/// <remarks>
/// Overrides <c>Start</c> and <c>Stop</c> to provide motorcycle-specific behavior.
/// Example:
/// <code>
/// Vehicle v = new MotorCycle();
/// v.Stop(); // Outputs "Motorcycle is stopping."
/// </code>
/// </remarks>
public class MotorCycle : Vehicle
{
    /// <inheritdoc />
    public override void Start()
    {
        Console.WriteLine("Motorcycle is starting.");
    }

    /// <inheritdoc />
    public override void Stop()
    {
        Console.WriteLine("Motorcycle is stopping.");
    }
}
