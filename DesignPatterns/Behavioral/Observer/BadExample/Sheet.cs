namespace DesignPatterns.Behavioral.Observer.BadExample;

/// <summary>
/// Represents a spreadsheet-like view that calculates and displays the total of values from a <see cref="DataSource"/>.
/// </summary>
/// <remarks>
/// <para>
/// In this bad example, the <see cref="Sheet"/> class is directly invoked by <see cref="DataSource"/>,
/// making them tightly coupled.
/// </para>
/// <para>
/// <b>Drawbacks:</b>
/// <list type="bullet">
///   <item>Changes in <see cref="Sheet"/> may require updates to <see cref="DataSource"/></item>
///   <item>Cannot be reused with a different data source without modification</item>
/// </list>
/// </para>
/// </remarks>
public class Sheet(int total)
{
    /// <summary>
    /// Retrieves the total value stored in the sheet.
    /// </summary>
    public int GetTotal() => total;

    /// <summary>
    /// Calculates the total from the given values and prints it.
    /// </summary>
    /// <param name="values">The list of integer values to sum.</param>
    /// <returns>The calculated sum of the values.</returns>
    public int CalculateTotal(List<int> values)
    {
        var sum = values.Sum();
        Console.WriteLine($"Total value: {sum}");
        return sum;
    }
}