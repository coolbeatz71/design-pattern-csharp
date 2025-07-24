namespace OopPrinciples.Inheritance;

public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }
    public int NumberOfWheels { get; set; }

    public void Start()
    {
        Console.WriteLine("Vehicle is starting.");
    }
}
