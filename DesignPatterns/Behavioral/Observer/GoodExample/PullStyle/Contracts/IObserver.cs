namespace DesignPatterns.Behavioral.Observer.GoodExample.PullStyle.Contracts;

/// <summary>
/// Defines the contract for observer objects in the <b>Pull Model</b> of the Observer Pattern.
/// </summary>
/// <remarks>
/// <para>
/// In the Pull Model, observers are notified that a change has occurred, but they must
/// actively pull (request) the data they need from the subject. This approach provides
/// more flexibility and reduces coupling.
/// </para>
/// <para>
/// <b>Advantages of Pull Model:</b>
/// <list type="bullet">
///   <item><b>Flexibility:</b> Observers can pull only the data they need.</item>
///   <item><b>Loose coupling:</b> Interface doesn't depend on specific data types.</item>
///   <item><b>Lazy loading:</b> Data is fetched only when needed.</item>
///   <item><b>Extensibility:</b> Easy to add new data types without changing interface.</item>
///   <item><b>Clean dependency management:</b> Subject is injected as dependency, not passed in updates.</item>
/// </list>
/// </para>
/// <para>
/// <b>Disadvantages:</b>
/// <list type="bullet">
///   <item><b>Multiple calls:</b> May result in multiple method calls to get data.</item>
///   <item><b>Subject reference:</b> Observers need reference to subject for data access.</item>
/// </list>
/// </para>
/// </remarks>
public interface IObserver
{
    /// <summary>
    /// Called by the subject when its state has changed. The observer pulls data from its injected subject.
    /// </summary>
    void Update();
}