namespace DesignPatterns.Behavioral.Observer.GoodExample.PullStyle.Contracts;

/// <summary>
/// Defines the contract for subject objects in the <b>Pull Model</b> of the Observer Pattern.
/// </summary>
/// <remarks>
/// <para>
/// In the Pull Model, subjects notify observers of changes but don't send data directly.
/// Observers must request (pull) the specific data they need.
/// </para>
/// </remarks>
public interface ISubject
{
    /// <summary>
    /// Registers an observer to receive notifications when the subject's state changes.
    /// </summary>
    /// <param name="observer">The observer to register.</param>
    void Subscribe(IObserver observer);
    
    /// <summary>
    /// Removes an observer from the notification list.
    /// </summary>
    /// <param name="observer">The observer to unregister.</param>
    void Unsubscribe(IObserver observer);
    
    /// <summary>
    /// Notifies all registered observers that state has changed, without sending data.
    /// </summary>
    void NotifyObservers();
    
    /// <summary>
    /// Allows observers to pull the current data values.
    /// </summary>
    /// <returns>The current list of values.</returns>
    List<int> GetValues();
}