namespace DesignPatterns.Behavioral.Command.RemoteControl.GoodExample;

public class TurnOnCommand(Light light): ICommand
{
    public void Execute()
    {
        light.TurnOn();
    }
}