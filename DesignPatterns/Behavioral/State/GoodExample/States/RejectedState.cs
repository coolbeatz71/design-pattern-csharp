using DesignPatterns.Behavioral.State.GoodExample.Contracts;
using DesignPatterns.Behavioral.State.GoodExample.Enums;
using DesignPatterns.Behavioral.State.GoodExample.Exceptions;

namespace DesignPatterns.Behavioral.State.GoodExample.States;

/// <summary>
/// Concrete State: Represents a document in the Rejected state within the State Pattern.
/// State-specific behavior: Rejected documents are in a terminal state with no available transitions.
/// Implements Interface Segregation Principle by only implementing the base IDocumentState interface.
/// This represents a "dead end" state in the workflow.
/// </summary>
public class RejectedState(Document document, IRoleValidator roleValidator): IPublishable
{
    /// <inheritdoc />
    public DocumentStateType StateType => DocumentStateType.Rejected;
    
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