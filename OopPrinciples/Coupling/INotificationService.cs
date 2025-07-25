namespace OopPrinciples.Coupling;

/// <summary>
/// Defines a contract for sending notifications such as emails or SMS.
/// </summary>
/// <remarks>
/// This interface enables decoupling between the consumer (e.g., <see cref="Order"/>) and the implementation (e.g., <see cref="EmailSender"/>).
/// 
/// Example usage in a high-level class:
/// <code>
/// public class Order
/// {
///     private readonly INotificationService _notificationService;
/// 
///     public Order(INotificationService notificationService)
///     {
///         _notificationService = notificationService;
///     }
/// 
///     public void Create()
///     {
///         _notificationService.Send("to@example.com", "Subject", "Message");
///     }
/// }
/// </code>
/// </remarks>
public interface INotificationService
{
    /// <summary>
    /// Sends a message to the specified recipient with the given subject and body.
    /// </summary>
    /// <param name="to">The recipient's address.</param>
    /// <param name="subject">The subject of the message.</param>
    /// <param name="body">The body of the message.</param>
    void Send(string to, string subject, string body);
}

