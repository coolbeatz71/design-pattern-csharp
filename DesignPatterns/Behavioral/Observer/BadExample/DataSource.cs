namespace DesignPatterns.Behavioral.Observer.BadExample;

public class DataSource
{
    private List<int> _values = [];
    private readonly List<object> _dependents = [];
    
    public List<int> GetValues() => _values;

    public void SetValues(List<int> values)
    {
        _values = values;
        
        // We need to update our dependents object
        foreach (var dependent in _dependents)
        {
            // This is going to be VERY messy if we end up with lots of dependents!!
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

    public void AddDependent(object dependent)
    {
        _dependents.Add(dependent);
    }

    public void RemoveDependent(object dependent)
    {
        _dependents.Remove(dependent);
    }
}