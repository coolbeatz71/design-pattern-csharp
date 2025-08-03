using DesignPatterns.Behavioral.State.GoodExample.Contracts;
using DesignPatterns.Behavioral.State.GoodExample.Enums;
using DesignPatterns.Behavioral.State.GoodExample.Exceptions;

namespace DesignPatterns.Behavioral.State.GoodExample.States;

public class RepublishedState(Document document, IRoleValidator roleValidator): ISuspendable
{
    /// <inheritdoc />
    public DocumentStateType StateType => DocumentStateType.Republished;
    
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