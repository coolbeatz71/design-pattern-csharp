namespace SolidPrinciples.SRP.BadExample;

/// <summary>
/// Represents a user of the system.
/// 
/// <para>
/// <b>SRP Violation:</b>
/// This class is responsible for more than one thing:
/// </para>
/// <list type="bullet">
///   <item>
///     <description>User data management (Username, Email)</description>
///   </item>
///   <item>
///     <description>User registration logic</description>
///   </item>
///   <item>
///     <description>Sending email notifications</description>
///   </item>
/// </list>
/// 
/// <para>
/// According to the Single Responsibility Principle (SRP),
/// a class should have only one reason to change. Here, if
/// the email sending mechanism changes (e.g., using a third-party service),
/// the <see cref="User"/> class would need to change as well,
/// violating SRP.
/// </para>
/// 
/// <example>
/// This shows how the class handles registration and email:
/// <code>
/// var user = new User
/// {
///     Username = "john_doe",
///     Email = "john@example.com"
/// };
/// user.Register();
/// </code>
/// </example>
/// </summary>
public class User
{
    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Registers the user and sends a welcome email.
    /// 
    /// <para>
    /// <b>SRP Violation:</b> This method handles both user registration
    /// and email sending. These are two separate responsibilities
    /// and should be decoupled into different classes.
    /// </para>
    /// </summary>
    public void Register()
    {
        // User registration logic (e.g., save to DB, validate, etc.)
        // ...

        // Responsibility 2: Send welcome email
        EmailSender emailSender = new EmailSender();
        emailSender.Send(
            to: Email,
            subject: "Welcome!",
            body: $"Hello {Username}, welcome to our platform!"
        );
    }
}
