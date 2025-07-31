using DesignPatterns.Behavioral.Memento.GoodExample;

namespace DesignPatterns;

public static class Program
{
    public static void Main()
    {
        RunMementoPatternDemo();
    }
    
    private static void RunMementoPatternDemo()
    {
        var editor = new Editor("Initial title", "Initial content");
        var history = new EditorHistory(editor);

        history.Save();
        editor.Show();

        editor.Edit("Updated title", "Updated content");
        history.Save();
        editor.Show();

        editor.Edit("Another updated title", "Another updated content");
        history.Save();
        editor.Show();

        editor.Edit("New updated title", "New updated content");
        editor.Show();

        history.Undo();
        editor.Show();

        history.ShowHistory();

        history.Undo();
        editor.Show();
    }
}