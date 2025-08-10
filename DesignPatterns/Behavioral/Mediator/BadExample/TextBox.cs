namespace DesignPatterns.Behavioral.Mediator.BadExample;

/// <summary>
/// Represents a text box that directly manipulates the dialog box.
/// </summary>
/// <remarks>
/// This class is poorly designed because it calls dialog box methods directly whenever text changes.
/// </remarks>
public class TextBox
{
    private readonly PostsDialogBox _dialogBox;
    private string? _text;

    /// <summary>
    /// Initializes the text box with a direct reference to the dialog box.
    /// </summary>
    public TextBox(PostsDialogBox dialogBox)
    {
        _dialogBox = dialogBox;
    }

    /// <summary>
    /// Simulates typing text into the text box.
    /// </summary>
    public void TypeText(string? text)
    {
        _text = text;
        _dialogBox.TitleChanged(text);
    }

    /// <summary>
    /// Sets the text directly, bypassing any validation.
    /// </summary>
    public void SetText(string? text)
    {
        _text = text;
    }

    /// <summary>
    /// Gets the current text value.
    /// </summary>
    public string? GetText()
    {
        return _text;
    }
}