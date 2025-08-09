using DesignPatterns.Behavioral.Observer.GoodExample.PullStyle.Contracts;

namespace DesignPatterns.Behavioral.Observer.GoodExample.PullStyle;

public class BarChart: IObserver
{
    private readonly ISubject _dataSource;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="BarChart"/> class.
    /// </summary>
    /// <param name="dataSource">The data source to observe and pull data from.</param>
    /// <exception cref="ArgumentNullException">Thrown when dataSource is null.</exception>
    public BarChart(ISubject dataSource)
    {
        _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
    }
    
    /// <summary>
    /// Updates the bar chart visualization when notified by the subject.
    /// Pulls the required data from the injected data source.
    /// </summary>
    public void Update()
    {
        var values = _dataSource.GetValues();
        Console.WriteLine($"[BarChart] Rendering with {values.Count} values: [{string.Join(", ", values)}]");
    }
}