namespace DesignPatterns.Behavioral.Observer.BadExample;

public class Sheet(int total)
{
    public int GetTotal() => total;
    
    public int CalculateTotal(List<int> values)
    {
        var sum = values.Sum();

        Console.WriteLine($"Total value: {sum}");
        return sum;
    }
}