using DesignPatterns.Behavioral.State.GoodExample.Enums;

namespace DesignPatterns.Behavioral.State.GoodExample.Contracts;

/// <summary>
/// Contract for role validation service used within the State Pattern.
/// Separates role-based authorization logic from state transition logic,
/// following the Single Responsibility Principle.
/// </summary>
public interface IRoleValidator
{
    /// <summary>
    /// Determines if a user role can submit documents for review.
    /// Used by ISubmittable implementations to validate permissions before state transitions.
    /// </summary>
    /// <param name="role">The user role to check.</param>
    /// <returns>True if the role can submit documents for review; otherwise, false.</returns>
    bool CanSubmitForReview(UserRoles role);
    
    /// <summary>
    /// Determines if a user role can publish documents.
    /// Used by IPublishable implementations to validate permissions before state transitions.
    /// </summary>
    /// <param name="role">The user role to check.</param>
    /// <returns>True if the role can publish documents; otherwise, false.</returns>
    bool CanPublish(UserRoles role);

    /// <summary>
    /// Determines if a user role can reject documents.
    /// Used by IRejectable implementations to validate permissions before state transitions.
    /// </summary>
    /// <param name="role">The user role to check.</param>
    /// <returns>True if the role can reject documents; otherwise, false.</returns>
    bool CanReject(UserRoles role);

    /// <summary>
    /// Determines if a user role can suspend documents.
    /// Used by ISuspendable implementations to validate permissions before state transitions.
    /// </summary>
    /// <param name="role">The user role to check.</param>
    /// <returns>True if the role can suspend documents; otherwise, false.</returns>
    bool CanSuspend(UserRoles role);

    /// <summary>
    /// Determines if a user role can unsuspend documents.
    /// Used by IRepublishable implementations to validate permissions before state transitions.
    /// </summary>
    /// <param name="role">The user role to check.</param>
    /// <returns>True if the role can unsuspend documents; otherwise, false.</returns>
    bool CanRepublish(UserRoles role);
}
