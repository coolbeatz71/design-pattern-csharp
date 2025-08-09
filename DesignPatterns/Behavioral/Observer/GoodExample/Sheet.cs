using DesignPatterns.Behavioral.Observer.GoodExample.Contracts;

namespace DesignPatterns.Behavioral.Observer.GoodExample;

/// <summary>
/// An observer that calculates the total sum of the integer values.
/// </summary>
/// <remarks>
/// <para>This observer prints the total sum when notified.</para>
/// <para>Example:</para>
/// <code>
/// var sheet = new Sheet();
/// sheet.Update(new List&lt;int&gt; { 5, 10, 15 });
/// // Output: [Sheet] Total value: 30
/// </code>
/// </remarks>
/// <remarks>
/// <para>
/// <b>Advantages over the bad example:</b>
/// <list type="bullet">
///   <item><b>Loose coupling:</b> No direct dependency on <see cref="DataSource"/></item>
///   <item><b>Automatic updates:</b> Receives notifications without explicit method calls</item>
///   <item><b>Reusable:</b> Can observe any subject that implements <see cref="ISubject"/></item>
/// </list>
/// </para>
/// </remarks>
public class Sheet: IObserver
{
    private int _total;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Sheet"/> class.
    /// </summary>
    /// <param name="initialTotal">The initial total value for the sheet.</param>
    public Sheet(int initialTotal = 0) => _total = initialTotal;
    
    /// <summary>
    /// Retrieves the current total value stored in the sheet.
    /// </summary>
    /// <returns>The current total value.</returns>
    private int GetTotal() => _total;
    
    /// <inheritdoc />
    public void Update(List<int> values)
    {
        _total = CalculateTotal(values);
        Console.WriteLine($"Sheet updated - Total value: {GetTotal()}");
    }
    
    /// <summary>
    /// Calculates the total from the given values and prints it.
    /// </summary>
    /// <param name="values">The list of integer values to sum.</param>
    /// <returns>The calculated sum of the values.</returns>
    private int CalculateTotal(List<int> values)
    {
        var sum = values.Sum();
        return sum;
    }
}