using DesignPatterns.Behavioral.State.GoodExample.Contracts;
using DesignPatterns.Behavioral.State.GoodExample.Enums;
using DesignPatterns.Behavioral.State.GoodExample.Exceptions;

namespace DesignPatterns.Behavioral.State.GoodExample.States;

/// <summary>
/// Concrete State: Represents a document in the Draft state within the State Pattern.
/// State-specific behavior: Draft documents can be submitted for review (Draft→Review) or rejected (Draft→Rejected).
/// Implements Interface Segregation Principle by only implementing interfaces for supported actions.
/// </summary>
public class DraftState(Document document, IRoleValidator roleValidator) : ISubmittable
{
    /// <inheritdoc />
    public DocumentStateType StateType => DocumentStateType.Draft;

    /// <inheritdoc />
    public void SubmitForReview(UserRoles userRole)
    {
        if (!roleValidator.CanSubmitForReview(userRole))
        {
            throw new UnauthorizedActionException(
                $"User with role '{userRole}' cannot submit documents for review."
            );
        }

        document.SetState(new ReviewState(document, roleValidator));
    }
}