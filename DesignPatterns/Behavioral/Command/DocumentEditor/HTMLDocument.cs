namespace DesignPatterns.Behavioral.Command.DocumentEditor;

/// <summary>
/// Represents an HTML document that can be manipulated through various formatting operations.
/// This class serves as the Receiver in the Command pattern, containing the business logic
/// for document operations that commands will invoke.
/// </summary>
/// <remarks>
/// <list type="bullet">
/// <item>Contains the document state and formatting operations</item>
/// <item>Provides methods that commands can call to modify content</item>
/// <item>Each method represents a specific business operation</item>
/// <item>Operations can be executed, undone, and potentially redone</item>
/// </list>
/// </remarks>
/// <param name="content">The initial HTML content of the document</param>
/// <example>
/// <code>
/// var document = new HTMLDocument("Hello World");
/// Console.WriteLine(document.Content); // Output: Hello World
/// 
/// document.MakeItalic();
/// Console.WriteLine(document.Content); // Output: &lt;i&gt;Hello World&lt;/i&gt;
/// </code>
/// </example>
public class HTMLDocument(string content)
{
    /// <summary>
    /// Gets or sets the HTML content of the document.
    /// This property represents the current state of the document
    /// and is modified by various formatting commands.
    /// </summary>
    /// <value>The HTML content as a string</value>
    public string Content { set; get; } = content;
    
    /// <summary>
    /// Wraps the current document content with italic HTML tags.
    /// This method implements the business logic for italic formatting
    /// and is called by the ItalicCommand during execution.
    /// </summary>
    /// <remarks>
    /// This method directly modifies the Content property by wrapping
    /// the existing content with &lt;i&gt; and &lt;/i&gt; tags.
    /// Commands should save the previous state before calling this method
    /// to enable undo functionality.
    /// </remarks>
    /// <example>
    /// <code>
    /// var document = new HTMLDocument("Hello");
    /// document.MakeItalic();
    /// Console.WriteLine(document.Content); // Output: &lt;i&gt;Hello&lt;/i&gt;
    /// 
    /// document.MakeItalic(); // Can be called multiple times
    /// Console.WriteLine(document.Content); // Output: &lt;i&gt;&lt;i&gt;Hello&lt;/i&gt;&lt;/i&gt;
    /// </code>
    /// </example>
    public void MakeItalic()
    {
        Content = $"<i>{Content}</i>";
    }
    
    /// <summary>
    /// Wraps the current document content with bold HTML tags.
    /// This method implements the business logic for bold formatting
    /// and is called by the BoldCommand during execution.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item>Directly modifies the Content property</item>
    /// <item>Wraps existing content with HTML bold tags</item>
    /// <item>Commands should save previous state before calling this method</item>
    /// <item>Required for undo functionality</item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// var document = new HTMLDocument("Hello");
    /// document.MakeBold();
    /// Console.WriteLine(document.Content); // Output: &lt;b&gt;Hello&lt;/b&gt;
    /// 
    /// document.MakeBold(); // Can be called multiple times
    /// Console.WriteLine(document.Content); // Output: &lt;b&gt;&lt;b&gt;Hello&lt;/b&gt;&lt;/b&gt;
    /// </code>
    /// </example>
    public void MakeBold()
    {
        Content = $"<b>{Content}</b>";
    }
}