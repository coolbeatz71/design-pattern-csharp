namespace OopPrinciples.Abstraction;

/// <summary>
/// A bad example of an email service that violates the Abstraction principle.
/// 
/// <para>
/// This class exposes low-level operations like <c>Connect</c>, <c>Authenticate</c>,
/// <c>SendEmail</c>, and <c>Disconnect</c> individually, forcing the consumer
/// to understand and manually coordinate the internal workflow required to send an email.
/// </para>
/// 
/// <para>
/// This breaks abstraction because the class should hide implementation details
/// and expose only the essential behavior (e.g., <c>Send(to, subject, body)</c>).
/// </para>
/// 
/// <para>Example of misuse:</para>
/// <code>
/// var service = new BadEmailService();
/// service.Connect();
/// service.Authenticate();
/// service.SendEmail();
/// service.Disconnect();
/// </code>
/// 
/// <para>
/// A better abstraction would encapsulate all these steps within a single high-level method,
/// allowing the consumer to send an email without worrying about internal mechanics.
/// </para>
/// </summary>
public class BadEmailService
{
    /// <summary>
    /// Simulates sending an email. Requires manual connection and authentication beforehand.
    /// </summary>
    public void SendEmail()
    {
        System.Console.WriteLine("Sending email...");
    }

    /// <summary>
    /// Simulates connecting to an email server.
    /// </summary>
    public void Connect()
    {
        System.Console.WriteLine("Connecting to email server...");
    }

    /// <summary>
    /// Simulates authenticating with an email server.
    /// </summary>
    public void Authenticate()
    {
        System.Console.WriteLine("Authenticating...");
    }

    /// <summary>
    /// Simulates disconnecting from the email server.
    /// </summary>
    public void Disconnect()
    {
        System.Console.WriteLine("Disconnecting from email server...");
    }
}
