namespace SolidPrinciples.SRP.GoodExample.Messaging;

/// <summary>
/// Defines the contract for sending email messages.
/// </summary>
public interface IEmailSender
{
    /// <summary>
    /// Sends the provided email message.
    /// </summary>
    /// <param name="message">The email message to be sent.</param>
    void Send(EmailMessage message);
}
