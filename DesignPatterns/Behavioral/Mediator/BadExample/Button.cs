namespace DesignPatterns.Behavioral.Mediator.BadExample;

/// <summary>
/// Represents a button that directly calls dialog box methods.
/// </summary>
/// <remarks>
/// This class is poorly designed because it calls the dialog box directly instead of raising events.
/// </remarks>
public class Button
{
    private readonly PostsDialogBox _dialogBox;
    private bool _isEnabled;

    /// <summary>
    /// Initializes the button with a direct reference to the dialog box.
    /// </summary>
    public Button(PostsDialogBox dialogBox)
    {
        _dialogBox = dialogBox;
    }

    /// <summary>
    /// Sets the enabled state of the button.
    /// </summary>
    public void SetEnabled(bool enabled)
    {
        _isEnabled = enabled;
    }

    /// <summary>
    /// Simulates a button click, calling the dialog box directly.
    /// </summary>
    public void Click()
    {
        if (_isEnabled) _dialogBox.SavePost();
    }
}