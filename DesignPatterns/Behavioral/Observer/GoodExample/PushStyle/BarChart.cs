using DesignPatterns.Behavioral.Observer.GoodExample.PushStyle.Contracts;

namespace DesignPatterns.Behavioral.Observer.GoodExample.PushStyle;

/// <summary>
/// An observer that simulates rendering a bar chart.
/// </summary>
/// <remarks>
/// <para>This observer prints a message indicating it rendered the values.</para>
/// <para>Example:</para>
/// <code>
/// var barChart = new BarChart();
/// barChart.Update(new List&lt;int&gt; { 3, 6, 9 });
/// // Output: [BarChart] Rendering with 3 values
/// </code>
/// </remarks>
/// <remarks>
/// <para>
/// <b>Improvements over the bad example:</b>
/// <list type="bullet">
///   <item><b>Loose coupling:</b> No direct dependency on <see cref="DataSource"/>.</item>
///   <item><b>Interface-based:</b> Implements <see cref="IObserver"/> for polymorphic treatment.</item>
///   <item><b>Reusable:</b> Can work with any subject that implements <see cref="ISubject"/>.</item>
/// </list>
/// </para>
/// </remarks>
public class BarChart : IObserver
{
    /// <summary>
    /// Updates the bar chart visualization when notified by the subject.
    /// </summary>
    /// <param name="values">A collection of integer values to visualize.</param>
    public void Update(List<int> values)
    {
        Console.WriteLine($"[BarChart] Rendering with {values.Count} values: [{string.Join(", ", values)}]");
    }
}