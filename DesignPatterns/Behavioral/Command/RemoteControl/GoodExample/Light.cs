namespace DesignPatterns.Behavioral.Command.RemoteControl.GoodExample;

public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Light is on");
    }

    public void TurnOff()
    {
        Console.WriteLine("Light is off");
    }

    public void Dim()
    {
        Console.WriteLine("Light is dim");
    }
}