using DesignPatterns.Behavioral.Observer.GoodExample.PullStyle.Contracts;

namespace DesignPatterns.Behavioral.Observer.GoodExample.PullStyle;

public class Sheet: IObserver
{
    private int _total;
    private readonly ISubject _dataSource;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Sheet"/> class.
    /// </summary>
    /// <param name="dataSource">The data source to observe and pull data from.</param>
    /// <param name="initialTotal">The initial total value for the sheet.</param>
    /// <exception cref="ArgumentNullException">Thrown when dataSource is null.</exception>
    public Sheet(ISubject dataSource, int initialTotal = 0)
    {
        _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
        _total = initialTotal;
    }
    
    /// <summary>
    /// Retrieves the current total value stored in the sheet.
    /// </summary>
    /// <returns>The current total value.</returns>
    public int GetTotal() => _total;
    
    /// <summary>
    /// Updates the sheet when notified by the subject.
    /// Pulls the data from the injected dependency and calculates the total.
    /// </summary>
    public void Update()
    {
        var values = _dataSource.GetValues();
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