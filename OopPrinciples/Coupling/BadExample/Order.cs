namespace OopPrinciples.Coupling.BadExample;

/// <summary>
/// Represents an order that triggers an email confirmation upon creation.
/// </summary>
/// <remarks>
/// This class is <b>tightly coupled</b> to <see cref="EmailSender"/> because it directly instantiates it inside the <c>Create</c> method.
/// <para>This violates the Dependency Inversion Principle, making it difficult to:</para>
/// <list type="bullet">
/// <item>Swap out email logic (e.g., use SMS, webhook, or a mock in tests)</item>
/// <item>Write unit tests without sending real emails</item>
/// <item>Follow the Open/Closed Principle</item>
/// </list>
/// 
/// Example of tight coupling:
/// <code>
/// public void Create()
/// {
///     EmailSender emailSender = new EmailSender(); // hard dependency
///     emailSender.Send(
///         "sigmacool@gmail.com", 
///         "Order Confirmation", 
///         "Your order has been created."
///     );
/// }
/// </code>
/// </remarks>
public class Order
{
    /// <summary>
    /// Simulates creating an order and sending an order confirmation email.
    /// </summary>
    public void Create()
    {
        // Simulate creating an order
        EmailSender emailSender = new EmailSender();
        emailSender.Send(
            to: "sigmacool@gmail.com",
            subject: "Order Confirmation",
            body: "Your order has been created successfully."
        );
    }
}
