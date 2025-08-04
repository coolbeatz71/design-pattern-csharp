namespace DesignPatterns.Behavioral.Command.RemoteControl.GoodExample;

public class DimCommand(Light light): ICommand
{
    public void Execute()
    {
        light.Dim();
    }
}