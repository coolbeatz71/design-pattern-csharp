using DesignPatterns.Behavioral.Observer.GoodExample.PullStyle.Contracts;

namespace DesignPatterns.Behavioral.Observer.GoodExample.PullStyle;

/// <summary>
/// Represents a data source that implements the <b>Pull Model</b> of the Observer Pattern.
/// </summary>
/// <remarks>
/// <para>
/// In the Pull Model, this data source only notifies observers that changes have occurred.
/// Observers must actively request (pull) the data they need through the provided methods.
/// </para>
/// <para>
/// <b>Pull Model Characteristics:</b>
/// <list type="bullet">
///   <item>Subject notifies observers of changes without sending data</item>
///   <item>Observers pull only the data they need</item>
///   <item>More flexible but potentially less efficient for simple scenarios</item>
///   <item>Supports multiple data access methods for different observer needs</item>
/// </list>
/// </para>
/// </remarks>
public class DataSource: ISubject
{
    private List<int> _values = [];
    private readonly List<IObserver> _observers = [];
    
    /// <summary>
    /// Registers an observer to receive pull notifications when the data changes.
    /// </summary>
    /// <param name="observer">The observer object that implements <see cref="IObserver"/>.</param>
    public void Subscribe(IObserver observer)
    {
        if (_observers.Contains(observer)) return;
        
        _observers.Add(observer);
        Console.WriteLine($"[PULL] Observer {observer.GetType().Name} subscribed");
    }
    
    /// <summary>
    /// Removes an observer from the pull notification list.
    /// </summary>
    /// <param name="observer">The observer object to remove.</param>
    public void Unsubscribe(IObserver observer)
    {
        if (_observers.Remove(observer))
        {
            Console.WriteLine($"[PULL] Observer {observer.GetType().Name} unsubscribed");
        }
    }
    
    /// <summary>
    /// Notifies all registered observers that data has changed, without sending data.
    /// </summary>
    public void NotifyObservers()
    {
        Console.WriteLine($"[PULL] Notifying {_observers.Count} observer(s) of changes...");
        foreach (var observer in _observers)
        {
            // Simple notification - observers pull data from their injected dependencies
            observer.Update();
        }
    }
    
    /// <summary>
    /// Updates the list of values and notifies all registered observers to pull new data.
    /// </summary>
    /// <param name="values">The new list of integer values.</param>
    public void SetValues(List<int> values)
    {
        _values = new List<int>(values);
        Console.WriteLine($"[PULL] DataSource updated with {values.Count} values");
        NotifyObservers();
    }
    
    /// <summary>
    /// Retrieves the current list of values stored in the data source.
    /// </summary>
    /// <returns>A copy of the current values list.</returns>
    public List<int> GetValues()
    {
        Console.WriteLine("[PULL] Observer requested values data");
        return [.._values];
    }
}