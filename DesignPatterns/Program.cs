using DesignPatterns.Behavioral.Memento.GoodExample;

var editor = new Editor(
    title: "Initial title",
    content:"Initial content"
);

var history = new EditorHistory(editor);
history.Save();
editor.Show();

editor.Title = "Updated title";
editor.Content = "Updated content";
history.Save();
editor.Show();

editor.Title = "Another updated title";
editor.Content = "Another updated content";
history.Save();
editor.Show();

history.Undo();
editor.Show();

history.ShowHistory();

history.Undo();
editor.Show();







