namespace DesignPatterns.Behavioral.Mediator.BadExample;

/// <summary>
/// Represents a post list box that directly manipulates the dialog box and other components.
/// </summary>
/// <remarks>
/// This class is poorly designed because it has knowledge of the entire dialog box,
/// instead of only handling its own responsibilities.
/// </remarks>
public class ListBox
{
    public string? SelectedItem { get; private set; }
    private readonly PostsDialogBox _dialogBox;

    /// <summary>
    /// Initializes the list box with a direct reference to the dialog box.
    /// </summary>
    public ListBox(PostsDialogBox dialogBox)
    {
        _dialogBox = dialogBox;
    }

    /// <summary>
    /// Selects a post and immediately updates the dialog box.
    /// </summary>
    public void SelectPost(string? title)
    {
        SelectedItem = title;
        _dialogBox.PostSelected(title);
    }
}