namespace SolidPrinciples.SRP.GoodExample.Messaging;

/// <summary>
/// Gets the recipient's email address.
/// Represents an email message with recipient, subject, and body content.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="EmailMessage"/> class.
/// </remarks>
/// <param name="to">Recipient email address.</param>
/// <param name="subject">Email subject line.</param>
/// <param name="body">Email body content.</param>
public class EmailMessage(string to, string subject, string body)
{
    /// <summary>
    /// Gets the recipient's email address.
    /// </summary>
    public string To { get; } = to;

    /// <summary>
    /// Gets the subject line of the email.
    /// </summary>
    public string Subject { get; } = subject;

    /// <summary>
    /// Gets the body content of the email.
    /// </summary>
    public string Body { get; } = body;
}
