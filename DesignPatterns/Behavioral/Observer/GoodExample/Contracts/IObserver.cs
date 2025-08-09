namespace DesignPatterns.Behavioral.Observer.GoodExample.Contracts;

/// <summary>
/// Defines the contract for all observers in the Observer Pattern.
/// </summary>
/// <remarks>
/// <para>
/// Classes implementing <see cref="IObserver"/> can subscribe to a subject
/// and receive updates when the subject's state changes.
/// </para>
/// <para>
/// <b>Benefits:</b>
/// <list type="bullet">
/// <item><b>Loose coupling:</b> Subjects only know about the interface, not concrete implementations.</item>
/// <item><b>Extensibility:</b> New observer types can be added without modifying existing code.</item>
/// <item><b>Polymorphism:</b> All observers are treated uniformly through the interface.</item>
/// </list>
/// </para>
/// <para>Usage example:</para>
/// <code>
/// public class MyObserver : IObserver
/// {
///     public void Update(List&lt;int&gt; values)
///     {
///         Console.WriteLine("Received updated values: " + string.Join(", ", values));
///     }
/// }
/// </code>
/// </remarks>
public interface IObserver
{
    /// <summary>
    /// Method called by the subject when the observed data changes.
    /// </summary>
    /// <param name="values">The latest state/data from the subject.</param>
    void Update(List<int> values);
}