using DesignPatterns.Behavioral.State.GoodExample.Contracts;
using DesignPatterns.Behavioral.State.GoodExample.Enums;
using DesignPatterns.Behavioral.State.GoodExample.Exceptions;

namespace DesignPatterns.Behavioral.State.GoodExample.States;

/// <summary>
/// Concrete State: Represents a document in the Review state within the State Pattern.
/// State-specific behavior: Review documents can be published (Review→Published) or rejected (Review→Rejected).
/// Implements Interface Segregation Principle by only implementing interfaces for supported actions.
/// </summary>
public class ReviewState(Document document, IRoleValidator roleValidator) : IPublishable, IRejectable
{
    /// <inheritdoc />
    public DocumentStateType StateType => DocumentStateType.Review;
    
    /// <inheritdoc />
    public void Reject(UserRoles userRole)
    {
        if (!roleValidator.CanReject(userRole))
        {
            throw new UnauthorizedActionException($"User with role '{userRole}' cannot reject documents.");
        }

        document.SetState(new RejectedState());
    }
    
    /// <inheritdoc />
    public void Publish(UserRoles userRole)
    {
        if (!roleValidator.CanPublish(userRole))
        {
            throw new UnauthorizedActionException($"User with role '{userRole}' cannot publish documents.");
        }

        document.SetState(new PublishedState(document, roleValidator));
    }
}