using DesignPatterns.Behavioral.State.GoodExample.Enums;
using DesignPatterns.Behavioral.State.GoodExample.Exceptions;

namespace DesignPatterns.Behavioral.State.GoodExample.Contracts;

/// <summary>
/// Contract for states that can be submitted for review in the State Pattern.
/// Implements Interface Segregation Principle - only states that support submission implement this interface.
/// Currently implemented by: DraftState
/// </summary>
public interface ISubmittable : IDocumentState
{
    /// <summary>
    /// Attempts to submit the document for review.
    /// </summary>
    /// <param name="userRole">The role of the user attempting the action.</param>
    /// <exception cref="UnauthorizedActionException">Thrown when the user lacks permission.</exception>
    void SubmitForReview(UserRoles userRole);
}