using DesignPatterns.Behavioral.State.GoodExample.Contracts;
using DesignPatterns.Behavioral.State.GoodExample.Enums;
using DesignPatterns.Behavioral.State.GoodExample.Exceptions;

namespace DesignPatterns.Behavioral.State.GoodExample.States;

/// <summary>
/// Concrete State: Represents a document in the Suspended state within the State Pattern.
/// State-specific behavior: Suspended documents can only be unsuspended (Suspended→Published).
/// Implements Interface Segregation Principle by only implementing interfaces for supported actions.
/// </summary>
public class SuspendedState(Document document, IRoleValidator roleValidator): IRepublishable
{
    /// <inheritdoc />
    public DocumentStateType StateType => DocumentStateType.Suspended;

    /// <inheritdoc />
    public void Republish(UserRoles userRole)
    {
        if (!roleValidator.CanRepublish(userRole))
        {
            throw new UnauthorizedActionException(
                $"User with role '{userRole}' cannot unsuspend documents. " +
                $"Only Admin and SuperAdmin can unsuspend documents."
            );
        }

        document.SetState(new RepublishedState());
    }
}