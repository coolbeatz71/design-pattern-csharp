namespace DesignPatterns.Behavioral.Mediator.BadExample;

/// <summary>
/// Represents a dialog box that manages posts in an extremely poor design,
/// where every component is directly dependent on every other component.
/// </summary>
/// <remarks>
/// This design is problematic because:
/// <list type="bullet">
///   <item>
///     <description>Every component directly manipulates the state of other components.</description>
///   </item>
///   <item>
///     <description>There is no separation of concerns; all logic is mixed together.</description>
///   </item>
///   <item>
///     <description>Adding a new component requires modifying multiple existing components.</description>
///   </item>
///   <item>
///     <description>Testing is nearly impossible because components cannot be isolated.</description>
///   </item>
/// </list>
/// 
/// <para>Example of the issue:</para>
/// <code>
/// _postsListBox.OnSelectionChanged = selection =>
/// {
///     _titleTextBox.SetText(selection);
///     _saveButton.SetEnabled(true);
/// };
/// </code>
/// </remarks>
public class PostsDialogBox
{
    private readonly ListBox _postsListBox;
    private readonly TextBox _titleTextBox;
    private readonly Button _saveButton;

    /// <summary>
    /// Initializes the dialog box with all components hardwired together.
    /// </summary>
    public PostsDialogBox()
    {
        _postsListBox = new ListBox(this);
        _titleTextBox = new TextBox(this);
        _saveButton = new Button(this);
    }

    /// <summary>
    /// Simulates user interaction in the worst possible way by having everything update everything else directly.
    /// </summary>
    public void SimulateUserInteraction()
    {
        _postsListBox.SelectPost("Post A");
        _titleTextBox.TypeText("New Title");
        _saveButton.Click();
    }

    /// <summary>
    /// Called when the post selection changes, directly updates the title text box and save button.
    /// </summary>
    public void PostSelected(string? title)
    {
        _titleTextBox.SetText(title);
        _saveButton.SetEnabled(true);
    }

    /// <summary>
    /// Called when the title text changes, directly enables the save button.
    /// </summary>
    public void TitleChanged(string? text)
    {
        _saveButton.SetEnabled(!string.IsNullOrWhiteSpace(text));
    }

    /// <summary>
    /// Called when the save button is clicked, directly prints the title text to console.
    /// </summary>
    public void SavePost()
    {
        Console.WriteLine($"Post saved: {_titleTextBox.GetText()}");
    }
}
