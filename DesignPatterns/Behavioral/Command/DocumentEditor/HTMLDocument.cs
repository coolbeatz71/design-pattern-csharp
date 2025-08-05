namespace DesignPatterns.Behavioral.Command.DocumentEditor;

public class HTMLDocument
{
    public string Content { set; get; }

    public void MakeItalic()
    {
        Content = $"<i>{Content}</i>";
    }
}