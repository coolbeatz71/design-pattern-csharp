namespace DesignPatterns.Behavioral.State.BadExample;

/// <summary>
/// Represents a document that can change status based on user actions and roles.
/// </summary>
/// <remarks>
/// ❌ <b>Violates the State Pattern Principles:</b>
/// <para>
/// 1. <b>No Encapsulation of State-specific Behavior:</b>
///    All state transition logic is in the <c>Document</c> class instead of being encapsulated in separate state objects.
/// </para>
/// <para>
/// 2. <b>Tight Coupling:</b>
///    The <c>Document</c> class is tightly coupled to every possible state and user role, making it hard to isolate logic.
/// </para>
/// <para>
/// 3. <b>Not Open for Extension:</b>
///    Adding new states or roles requires modifying the <c>Document</c> class, which violates the Open/Closed Principle.
/// </para>
/// <para>
/// 4. <b>Conditional Explosion:</b>
///    The logic relies on nested <c>if</c>/<c>else</c> conditions to determine transitions,
///    which becomes hard to manage and error-prone as new cases are added.
/// </para>
/// </remarks>
public class Document
{
    /// <summary>
    /// Gets or sets the current status of the document.
    /// </summary>
    private DocumentStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the role of the user interacting with the document.
    /// </summary>
    private UserRoles CurrentUserRole { get; set; }

    /// <summary>
    /// Attempts to publish the document based on its current status and user role.
    /// </summary>
    public void Publish()
    {
        switch (Status)
        {
            case DocumentStatus.Draft:
                Console.WriteLine("Document moved from Draft to Moderated.");
                Status = DocumentStatus.Moderated;
                break;
            case DocumentStatus.Moderated when CurrentUserRole is UserRoles.Admin or UserRoles.SuperAdmin:
                Console.WriteLine("Document moved from Moderated to Published.");
                Status = DocumentStatus.Published;
                break;
            case DocumentStatus.Moderated:
                Console.WriteLine("Only Admins can publish a moderated document.");
                break;
            case DocumentStatus.Published:
                Console.WriteLine("Document is already published. No further publishing action needed.");
                break;
            case DocumentStatus.Suspended:
                Console.WriteLine("Suspended documents cannot be published.");
                break;
            default:
                Console.WriteLine("Invalid state transition.");
                break;
        }
    }

    /// <summary>
    /// Attempts to suspend the document if it is in the Published state.
    /// </summary>
    public void Suspend()
    {
        if (Status == DocumentStatus.Published)
        {
            if (CurrentUserRole is UserRoles.Admin or UserRoles.SuperAdmin)
            {
                Console.WriteLine("Document has been suspended.");
                Status = DocumentStatus.Suspended;
            }
            else
            {
                Console.WriteLine("Only Admins can suspend a document.");
            }
        }
        else
        {
            Console.WriteLine("Only published documents can be suspended.");
        }
    }

    /// <summary>
    /// Attempts to moderate the document if it is in the Draft state.
    /// </summary>
    public void Moderate()
    {
        if (Status == DocumentStatus.Draft)
        {
            if (CurrentUserRole is UserRoles.Moderator or UserRoles.Admin)
            {
                Console.WriteLine("Document has been moderated.");
                Status = DocumentStatus.Moderated;
            }
            else
            {
                Console.WriteLine("Only Moderators or Admins can moderate drafts.");
            }
        }
        else
        {
            Console.WriteLine("Only draft documents can be moderated.");
        }
    }

    /// <summary>
    /// Displays the current document status in the console.
    /// </summary>
    public void PrintStatus()
    {
        Console.WriteLine($"Current Status: {Status}");
    }
}

