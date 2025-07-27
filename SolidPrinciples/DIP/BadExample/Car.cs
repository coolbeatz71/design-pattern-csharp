namespace SolidPrinciples.DIP.BadExample;

public class Car
{
    private Engine engine;

    public Car()
    {
        engine = new Engine();
    }

    public void Start()
    {
        engine.Start();
        Console.WriteLine("Car started");
    }
}