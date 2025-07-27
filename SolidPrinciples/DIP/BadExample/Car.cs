namespace SolidPrinciples.DIP.BadExample;

/// <summary>
/// Represents a car that depends directly on a concrete <see cref="Engine"/>.
/// </summary>
/// <remarks>
/// ❌ <b>Violates the Dependency Inversion Principle (DIP):</b>
/// 
/// <para>
/// This class creates a concrete instance of <see cref="Engine"/> within its constructor,
/// which results in a high-level module (<see cref="Car"/>) depending on a low-level module (<see cref="Engine"/>).
/// </para>
///
/// <para>
/// According to the DIP:
/// <list type="bullet">
///   <item><description>High-level modules should not depend on low-level modules. Both should depend on abstractions.</description></item>
///   <item><description>Abstractions should not depend on details. Details should depend on abstractions.</description></item>
/// </list>
/// </para>
///
/// <para>
/// In this example:
/// <list type="bullet">
///   <item><description>The <see cref="Car"/> class cannot work with any other kind of engine (e.g., mock engine for tests, electric engine, hybrid engine).</description></item>
///   <item><description>It is tightly coupled to the <see cref="Engine"/> class, making it hard to extend or maintain.</description></item>
/// </list>
/// </para>
///
/// <para>
/// ✅ To follow DIP, you should depend on an abstraction (e.g., <c>IEngine</c>) and inject it via constructor or property.
/// </para>
/// </remarks>
public class Car
{
    private readonly Engine _engine;

    /// <summary>
    /// Initializes a new instance of the <see cref="Car"/> class with a direct dependency on <see cref="Engine"/>.
    /// </summary>
    public Car()
    {
        _engine = new Engine(); // ❌ Hard dependency — violates DIP
    }

    /// <summary>
    /// Starts the car by starting the engine first.
    /// </summary>
    public void Start()
    {
        _engine.Start();
        Console.WriteLine("Car started");
    }
}