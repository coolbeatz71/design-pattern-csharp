namespace OopPrinciples.Coupling;

/// <summary>
/// A concrete implementation of <see cref="INotificationService"/> that sends emails.
/// </summary>
/// <remarks>
/// Implements the <c>Send</c> method for email delivery. 
/// <para>This class can be swapped with other implementations
/// (e.g., SMS, Push Notifications) without affecting the consumer.
/// </para>
/// 
/// Example:
/// <code>
/// INotificationService sender = new EmailSender();
/// sender.Send("to@example.com", "Hello", "Message body");
/// </code>
/// </remarks>
public class EmailSender : INotificationService
{
    /// <summary>
    /// Sends an email to the specified address with a subject and body.
    /// </summary>
    /// <param name="to">The recipient's email address.</param>
    /// <param name="subject">The subject of the email.</param>
    /// <param name="body">The body content of the email.</param>
    public void Send(string to, string subject, string body)
    {
        // Simulate sending an email
        Console.WriteLine($"Sending email to {to} with subject '{subject}' and body '{body}'");
    }

}
