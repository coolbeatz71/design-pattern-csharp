using DesignPatterns.Behavioral.State.GoodExample.Enums;
using DesignPatterns.Behavioral.State.GoodExample.Exceptions;

namespace DesignPatterns.Behavioral.State.GoodExample.Contracts;

/// <summary>
/// Contract for states that can be unsuspended (restored to published) in the State Pattern.
/// Implements Interface Segregation Principle - only states that support republishing implement this interface.
/// Currently implemented by: SuspendedState
/// </summary>
public interface IRepublishable : IDocumentState
{
    /// <summary>
    /// Attempts to republish the document, returning it to published state.
    /// </summary>
    /// <param name="userRole">The role of the user attempting the action.</param>
    /// <exception cref="UnauthorizedActionException">Thrown when the user lacks permission.</exception>
    void Republish(UserRoles userRole);
}