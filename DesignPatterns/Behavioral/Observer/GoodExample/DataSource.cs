using DesignPatterns.Behavioral.Observer.GoodExample.Contracts;

namespace DesignPatterns.Behavioral.Observer.GoodExample;

/// <summary>
/// A concrete subject that holds a list of integer values.
/// </summary>
/// <remarks>
/// <para>
/// Observers can subscribe to this class to receive updates when data changes.
/// </para>
/// <para>Example usage:</para>
/// <code>
/// var dataSource = new DataSource();
/// var sheet = new Sheet();
/// var barChart = new BarChart();
/// 
/// dataSource.Attach(sheet);
/// dataSource.Attach(barChart);
/// 
/// dataSource.SetValues(new List&lt;int&gt; { 1, 2, 3 });
/// // Outputs:
/// // [Sheet] Total value: 6
/// // [BarChart] Rendering with 3 values
/// </code>
/// </remarks>
public class DataSource: ISubject
{
    private List<int> _values = [];
    private readonly List<IObserver> _observers = [];
    
    /// <summary>
    /// Gets the current list of integer values.
    /// </summary>
    public List<int> GetValues => [.._values];
    
    /// <summary>
    /// Sets new values and notifies all observers of this change.
    /// </summary>
    /// <param name="values">New list of integer values.</param>
    public void SetValues(List<int> values)
    {
        _values = new List<int>(values); // Create a defensive copy
        
        Console.WriteLine($"DataSource updated with {values.Count} values");
        NotifyObservers();
    }
    
    /// <summary>
    /// Registers an observer to receive notifications when the data changes.
    /// </summary>
    /// <param name="observer">The observer object that implements <see cref="IObserver"/>.</param>
    /// <remarks>
    /// <para>
    /// Unlike the bad example that accepted any <c>object</c>, this method only accepts
    /// objects implementing <see cref="IObserver"/>, ensuring type safety and proper behavior.
    /// </para>
    /// </remarks>
    public void Subscribe(IObserver observer)
    {
        if (_observers.Contains(observer)) return;
        
        _observers.Add(observer);
        Console.WriteLine($"Observer {observer.GetType().Name} subscribed");
    }
    
    /// <summary>
    /// Removes an observer from the notification list.
    /// </summary>
    /// <param name="observer">The observer object to remove.</param>
    public void Unsubscribe(IObserver observer)
    {
        if (_observers.Remove(observer))
        {
            Console.WriteLine($"Observer {observer.GetType().Name} unsubscribed");
        }
    }
    
    /// <summary>
    /// Notifies all registered observers that the data has changed.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This method demonstrates the power of polymorphism in the Observer Pattern.
    /// All observers are treated uniformly through the <see cref="IObserver"/> interface,
    /// regardless of their concrete implementations.
    /// </para>
    /// </remarks>
    public void NotifyObservers()
    {
        Console.WriteLine($"Notifying {_observers.Count} observer(s)...");
        foreach (var observer in _observers)
        {
            observer.Update(_values);
        }
    }
}