using DesignPatterns.Behavioral.State.GoodExample.Enums;
using DesignPatterns.Behavioral.State.GoodExample.Exceptions;

namespace DesignPatterns.Behavioral.State.GoodExample.Contracts;

/// <summary>
/// Contract for states that can be rejected in the State Pattern.
/// Implements Interface Segregation Principle - only states that support rejection implement this interface.
/// Currently implemented by: DraftState, ReviewState
/// </summary>
public interface IRejectable : IDocumentState
{
    /// <summary>
    /// Attempts to reject the document.
    /// </summary>
    /// <param name="userRole">The role of the user attempting the action.</param>
    /// <exception cref="UnauthorizedActionException">Thrown when the user lacks permission.</exception>
    void Reject(UserRoles userRole);
}