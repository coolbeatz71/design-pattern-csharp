namespace DesignPatterns.Behavioral.Command.RemoteControl.GoodExample;

public class TurnOffCommand(Light light): ICommand
{
    public void Execute()
    {
        light.TurnOff();
    }
}