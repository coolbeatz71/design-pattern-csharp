namespace OopPrinciples.Coupling;

/// <summary>
/// Represents an order that uses a notification service to send confirmations.
/// </summary>
/// <remarks>
/// This class is now <b>decoupled</b> from the concrete implementation of email sending by depending on the abstraction <see cref="INotificationService"/>.
/// 
/// Benefits:
/// <list type="bullet">
/// <item>Follows the Dependency Inversion Principle</item>
/// <item>Easy to test using mocks or stubs</item>
/// <item>Can switch notification mechanisms without modifying this class</item>
/// </list>
/// 
/// Example:
/// <example>
/// <code>
/// INotificationService notificationService = new EmailSender(); // or MockNotificationService
/// Order order = new Order(notificationService);
/// order.Create(); // Sends email without tightly coupling to EmailSender
/// </code>
/// </example>
/// </remarks>
public class Order
{
    private readonly INotificationService _notificationService;

    /// <summary>
    /// Initializes a new instance of the <see cref="Order"/> class using a notification service.
    /// </summary>
    /// <param name="notificationService">The service used to send order confirmations.</param>
    public Order(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    /// <summary>
    /// Simulates creating an order and sending a notification.
    /// </summary>
    public void Create()
    {
        // Logic to create an order
        // ...

        // Send notification
        _notificationService.Send(
            to: "sigmacool@gmail.com",
            subject: "Order Confirmation",
            body: "Your order has been created successfully."
        );
    }
}
