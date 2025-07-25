namespace OopPrinciples.Coupling.BadExample;

/// <summary>
/// A concrete class responsible for sending emails.
/// </summary>
/// <remarks>
/// This class simulates sending an email by writing to the console. 
/// 
/// While functional, when used directly in other classes (e.g., <see cref="Order"/>), it leads to tight coupling:
/// <code>
/// var emailSender = new EmailSender(); // direct dependency
/// emailSender.Send("to@example.com", "Subject", "Body");
/// </code>
/// </remarks>
public class EmailSender
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
