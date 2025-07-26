namespace SolidPrinciples.SRP.GoodExample.Services;

/// <summary>
/// Provides user-related operations such as registration and notification.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UserService"/> class.
/// </remarks>
/// <param name="emailSender">
/// An implementation of <see cref="IEmailSender"/> used to deliver email notifications.
/// </param>
public class UserService(IEmailSender emailSender)
{

    /// <summary>
    /// Registers the specified user and sends them a welcome email.
    /// </summary>
    /// <param name="user">The user to register.</param>
    /// <remarks>
    /// This method simulates user registration (e.g., validation, database persistence)
    /// and uses the provided <see cref="IEmailSender"/> to send a welcome message.
    /// </remarks>
    /// <example>
    /// The following example demonstrates how to register a user and send a welcome email:
    /// <code>
    /// var user = new User
    /// {
    ///     Username = "john_doe",
    ///     Email = "john@example.com"
    /// };
    ///
    /// IEmailSender emailSender = new ConsoleEmailSender();
    /// var userService = new UserService(emailSender);
    ///
    /// userService.Register(user);
    /// </code>
    /// </example>
    public void Register(User user)
    {
        // Step 1: Perform user registration logic
        // (e.g., validation, saving to DB – omitted for brevity)

        // Step 2: Send welcome email
        var message = new EmailMessage(
            to: user.Email,
            subject: "Welcome!",
            body: $"Hello {user.Username}, welcome to our platform!"
        );

        emailSender.Send(message);
    }
}
