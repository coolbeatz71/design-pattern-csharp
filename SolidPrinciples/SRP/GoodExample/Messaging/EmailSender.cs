namespace SolidPrinciples.SRP.GoodExample.Messaging;

/// <summary>
/// Simulates sending emails by writing them to the console.
/// </summary>
public class EmailSender : IEmailSender
{
    /// <inheritdoc />
    public void Send(EmailMessage message)
    {
        Console.WriteLine($"[EmailSender] To: {message.To}");
        Console.WriteLine($"Subject: {message.Subject}");
        Console.WriteLine($"Body: {message.Body}");
    }
}
