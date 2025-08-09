namespace DesignPatterns.Behavioral.Observer.BadExample;

/// <summary>
/// Represents the data model in this bad Observer example.
/// </summary>
/// <remarks>
/// <para>
/// This class stores and manages a list of integer values, and it is responsible for
/// notifying dependent objects whenever data changes.
/// </para>
/// <para>
/// <b>Why this implementation is bad:</b>
/// <list type="bullet">
///   <item><b>Tight coupling:</b> The class explicitly knows and checks the types of its dependents (<see cref="BarChart"/>, <see cref="Sheet"/>).</item>
///   <item><b>Violation of Open/Closed Principle:</b> Adding a new dependent type (e.g., <c>PieChart</c>) requires modifying this class.</item>
///   <item><b>Poor scalability:</b> As the number of dependents grows, the <c>switch</c> statement becomes larger and harder to maintain.</item>
/// </list>
/// </para>
/// <para>
/// <b>Better Approach:</b> Use the <b>Observer Pattern</b> by introducing a common 
/// <c>IObserver</c> interface that all dependents implement, allowing the subject 
/// (<see cref="DataSource"/>) to notify them without knowing their concrete types.
/// </para>
/// </remarks>
public class DataSource
{
    private List<int> _values = [];
    private readonly List<object> _dependents = [];

    /// <summary>
    /// Retrieves the current list of values stored in the data source.
    /// </summary>
    public List<int> GetValues() => _values;

    /// <summary>
    /// Updates the list of values and refreshes all registered dependents.
    /// </summary>
    /// <param name="values">The new list of integer values.</param>
    public void SetValues(List<int> values)
    {
        _values = values;

        // Notifying dependents (Bad: tightly coupled and type-dependent logic)
        foreach (var dependent in _dependents)
        {
            switch (dependent)
            {
                case Sheet sheet:
                    sheet.CalculateTotal(_values);
                    break;
                case BarChart barChart:
                    barChart.Render(_values);
                    break;
            }
        }
    }

    /// <summary>
    /// Registers a dependent object to be updated when the data changes.
    /// </summary>
    /// <param name="dependent">The dependent object (view or other observer).</param>
    public void AddDependent(object dependent)
    {
        _dependents.Add(dependent);
    }

    /// <summary>
    /// Removes a dependent object from the update list.
    /// </summary>
    /// <param name="dependent">The dependent object to remove.</param>
    public void RemoveDependent(object dependent)
    {
        _dependents.Remove(dependent);
    }
}