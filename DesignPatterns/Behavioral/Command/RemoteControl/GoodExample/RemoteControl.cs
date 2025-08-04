namespace DesignPatterns.Behavioral.Command.RemoteControl.GoodExample;

public class RemoteControl(ICommand command)
{
    private ICommand _command = command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }
}