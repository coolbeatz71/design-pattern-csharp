using System.Text;

namespace DesignPatterns.Behavioral.Command.TextEditor;

// receiver
public class TextEditor
{
    private readonly StringBuilder _content  = new();

    public void InsertText(string text, int position)
    {
        _content.Insert(position, text);
        Console.WriteLine($"Inserted '{text}' at position {position}");
    }

    public void DeleteText(int position, int length)
    {
        _content.Remove(position, length);
        Console.WriteLine($"Deleted {length} characters at position {position}");
    }
    
    public string GetContent() => _content.ToString();
}