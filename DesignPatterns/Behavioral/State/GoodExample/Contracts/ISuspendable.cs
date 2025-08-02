using DesignPatterns.Behavioral.State.GoodExample.Enums;
using DesignPatterns.Behavioral.State.GoodExample.Exceptions;

namespace DesignPatterns.Behavioral.State.GoodExample.Contracts;

/// <summary>
/// Contract for states that can be suspended in the State Pattern.
/// Implements Interface Segregation Principle - only states that support suspension implement this interface.
/// Currently implemented by: PublishedState
/// </summary>
public interface ISuspendable : IDocumentState
{
    /// <summary>
    /// Attempts to suspend the document.
    /// </summary>
    /// <param name="userRole">The role of the user attempting the action.</param>
    /// <exception cref="UnauthorizedActionException">Thrown when the user lacks permission.</exception>
    void Suspend(UserRoles userRole);
}
