namespace OopPrinciples.Abstraction;

/// <summary>
/// Represents an email service that abstracts the details of connecting,
/// authenticating, sending, and disconnecting from the email server.
/// </summary>
public class EmailService
{
    /// <summary>
    /// Sends an email with the specified parameters.
    /// This method handles connecting, authenticating, sending, and disconnecting internally,
    /// hiding all implementation details from the caller.
    /// </summary>
    /// <param name="to">The recipient's email address.</param>
    /// <param name="subject">The email subject.</param>
    /// <param name="body">The email body content.</param>
    public void Send(string to, string subject, string body)
    {
        Connect();
        Authenticate();
        SendEmail(to, subject, body);
        Disconnect();
    }

    /// <summary>
    /// Connects to the email server.
    /// </summary>
    private void Connect()
    {
        System.Console.WriteLine("Connecting to email server...");
    }

    /// <summary>
    /// Authenticates with the email server.
    /// </summary>
    private void Authenticate()
    {
        System.Console.WriteLine("Authenticating...");
    }

    /// <summary>
    /// Sends the email. This method is called internally by <see cref="Send"/>.
    /// </summary>
    /// <param name="to">The recipient's email address.</param>
    /// <param name="subject">The email subject.</param>
    /// <param name="body">The email body content.</param>
    private void SendEmail(string to, string subject, string body)
    {
        System.Console.WriteLine($"Sending email to {to} with subject '{subject}' and body '{body}'.");
    }

    /// <summary>
    /// Disconnects from the email server.
    /// </summary>
    private void Disconnect()
    {
        System.Console.WriteLine("Disconnecting from email server...");
    }
}
