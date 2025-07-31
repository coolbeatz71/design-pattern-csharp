namespace DesignPatterns.Behavioral.Memento.BadExample;

/// <summary>
/// ❌ A flawed approach to saving and restoring the state of an object manually.
///
/// <para><b>What this is trying to solve:</b></para>
/// Many applications need undo functionality or the ability to save and restore object states.
/// However, doing so manually introduces several architectural and maintenance issues.
///
/// <list type="number">
///   <item>
///     <description>Internal state is exposed through public getters, tightly coupling external code to internal details.</description>
///   </item>
///   <item>
///     <description>State is tracked separately for each property. There's no cohesive representation of the object's full state.</description>
///   </item>
///   <item>
///     <description>Undo operations apply independently to content and title, which can easily desynchronize object state.</description>
///   </item>
///   <item>
///     <description>Calling 'Last()' or removing from an empty list will cause runtime exceptions.</description>
///   </item>
///   <item>
///     <description>More state fields increases code duplication and complexity—every field requires its own history list and undo method.</description>
///   </item>
///   <item>
///     <description>Undo logic is embedded in the business object itself, bloating its responsibilities and making the code harder to reason about.</description>
///   </item>
/// </list>
/// </summary>
public class Editor
{
    private string _content = "";
    private readonly List<string> _prevContentList = [];

    private string _title = "";
    private readonly List<string> _prevTitleList = [];

    /// <summary>
    /// Returns the current content.
    /// ❌ Breaks encapsulation by exposing private state to the outside world.
    /// </summary>
    public string GetContent()
    {
        return _content;
    }

    /// <summary>
    /// Returns the current title.
    /// ❌ Same issue as GetContent: external code can now make decisions based on internal state.
    /// </summary>
    public string GetTitle()
    {
        return _title;
    }

    /// <summary>
    /// Updates the title and pushes the new value into a history list.
    /// ❌ Only the title is saved here—if other parts of the object are modified in parallel, 
    /// there's no consistent way to restore the full previous state.
    /// </summary>
    public void SetTitle(string title)
    {
        _prevTitleList.Add(title);
        _title = title;
    }

    /// <summary>
    /// Updates the content and stores the new value in a separate list.
    /// ❌ Treating properties independently makes coordinated undo operations fragile.
    /// </summary>
    public void SetContent(string content)
    {
        _prevContentList.Add(content);
        _content = content;
    }

    /// <summary>
    /// Attempts to undo the last content update.
    /// ❌ This method is unsafe — if the list is empty, it throws.
    /// ❌ Partial undo: Only content is restored, title is untouched.
    /// </summary>
    public void UndoContent()
    {
        var lastContent = _prevContentList.Last();
        _prevContentList.Remove(lastContent);
        _content = lastContent;
    }

    /// <summary>
    /// Attempts to undo the last title update.
    /// ❌ Same problems as UndoContent: no safety checks, no coordination with other changes.
    /// </summary>
    public void UndoTitle()
    {
        var lastTitle = _prevTitleList.Last();
        _prevTitleList.Remove(lastTitle);
        _title = lastTitle;
    }

    /// <summary>
    /// Attempts to undo both title and content changes.
    /// ❌ There’s no guarantee that these changes were made at the same time.
    /// ❌ Can easily lead to inconsistent or invalid state.
    /// ❌ If either history list is empty, the application will crash.
    /// </summary>
    public void Undo()
    {
        UndoTitle();
        UndoContent();
    }
}
