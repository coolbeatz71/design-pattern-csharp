using DesignPatterns.Behavioral.State.GoodExample.Enums;
using DesignPatterns.Behavioral.State.GoodExample.Exceptions;

namespace DesignPatterns.Behavioral.State.GoodExample.Contracts;

/// <summary>
/// Contract for states that can be published in the State Pattern.
/// Implements Interface Segregation Principle - only states that support publishing implement this interface.
/// Currently implemented by: ReviewState
/// </summary>
public interface IPublishable: IDocumentState
{
    /// <summary>
    /// Attempts to publish the document.
    /// </summary>
    /// <param name="userRole">The role of the user attempting the action.</param>
    /// <exception cref="UnauthorizedActionException">Thrown when the user lacks permission.</exception>
    void Publish(UserRoles userRole);
}