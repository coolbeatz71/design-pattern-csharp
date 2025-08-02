using DesignPatterns.Behavioral.State.GoodExample.Contracts;
using DesignPatterns.Behavioral.State.GoodExample.Enums;
using DesignPatterns.Behavioral.State.GoodExample.Exceptions;

namespace DesignPatterns.Behavioral.State.GoodExample.States;

/// <summary>
/// Concrete State: Represents a document in the Published state within the State Pattern.
/// State-specific behavior: Published documents can only be suspended (Published→Suspended).
/// Implements Interface Segregation Principle by only implementing interfaces for supported actions.
/// </summary>
public class PublishedState(Document document, IRoleValidator roleValidator): ISuspendable
{
    /// <inheritdoc />
    public DocumentStateType StateType => DocumentStateType.Published;
    
    /// <inheritdoc />
    public void Suspend(UserRoles userRole)
    {
        if (!roleValidator.CanSuspend(userRole))
        {
            throw new UnauthorizedActionException(
                $"User with role '{userRole}' cannot suspend documents. " +
                $"Only Admin and SuperAdmin can suspend documents."
            );
        }

        document.SetState(new SuspendedState(document, roleValidator));
    }
}