namespace DesignPatterns.Behavioral.Observer.BadExample;

/// <summary>
/// Represents a <b>bar chart</b> UI component that visualizes a list of integer values.
/// </summary>
/// <remarks>
/// <para>
/// In this <i>bad example</i> of the Observer Pattern, the <see cref="BarChart"/> class
/// is tightly coupled to the <see cref="DataSource"/> class, which directly calls 
/// <see cref="Render"/> when data changes.
/// </para>
/// <para>
/// This is problematic because:
/// <list type="bullet">
///   <item>It forces <see cref="DataSource"/> to know about the <see cref="BarChart"/> implementation details.</item>
///   <item>Adding new dependent types requires modifying <see cref="DataSource"/>, breaking the Open/Closed Principle.</item>
///   <item>It becomes messy and error-prone when the number of dependent views increases.</item>
/// </list>
/// </para>
/// </remarks>
public class BarChart
{
    /// <summary>
    /// Renders the bar chart with the provided values.
    /// </summary>
    /// <param name="values">A collection of integer values to visualize.</param>
    public void Render(List<int> values)
    {
        Console.WriteLine("Rendering bar chart with new values");
    }
}