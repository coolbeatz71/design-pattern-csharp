namespace SolidPrinciples.SRP.BadExample;

/// <summary>
/// Provides functionality to send email messages.
/// </summary>
public class EmailSender
{
    /// <summary>
    /// Sends an email to the specified address with a subject and body.
    /// </summary>
    /// <param name="to">The recipient's email address.</param>
    /// <param name="subject">The subject of the email.</param>
    /// <param name="body">The body content of the email.</param>
    /// <example>
    /// Example usage:
    /// <code>
    /// var emailSender = new EmailSender();
    /// emailSender.Send(
    ///     to: "jane@example.com",
    ///     subject: "Welcome",
    ///     body: "Hello Jane, welcome to our application!"
    /// );
    /// </code>
    /// </example>
    public void Send(string to, string subject, string body)
    {
        // Simulate sending an email
        Console.WriteLine($"Sending email to {to} with subject '{subject}' and body '{body}'");
    }
}
