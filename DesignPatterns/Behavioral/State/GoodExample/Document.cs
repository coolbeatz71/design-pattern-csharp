using DesignPatterns.Behavioral.State.GoodExample.Contracts;
using DesignPatterns.Behavioral.State.GoodExample.Enums;
using DesignPatterns.Behavioral.State.GoodExample.Exceptions;
using DesignPatterns.Behavioral.State.GoodExample.States;

namespace DesignPatterns.Behavioral.State.GoodExample;

/// <summary>
/// Represents the context in the State design pattern, modeling a document whose behavior changes based on its internal state.
/// 
/// This class delegates state-specific behavior to encapsulated state objects and exposes a stable interface to clients
/// while managing transitions between states internally.
/// <para><b>State Pattern Advantages Demonstrated:</b></para>
/// <list type="bullet">
///   <item>Replaces complex conditional logic with polymorphic state classes</item>
///   <item>Enforces explicit, controlled state transitions</item>
///   <item>Enables extensibility by adding new states without modifying the context</item>
///   <item>Improves maintainability by isolating state-specific behavior</item>
/// </list>
/// </summary>
public class Document
{
    private IDocumentState _currentState;
    
    public Document(IRoleValidator roleValidator)
    {
        _currentState = new DraftState(this, roleValidator);
    }

    /// <summary>
    /// Gets the current state type of the document.
    /// </summary>
    public DocumentStateType CurrentStateType => _currentState.StateType;
    
    /// <summary>
    /// Sets the internal state of the document. This method is used by state implementations.
    /// </summary>
    /// <param name="newState">The new state to set.</param>
    internal void SetState(IDocumentState newState)
    {
        _currentState = newState ?? throw new ArgumentNullException(nameof(newState));
    }
    
    /// <summary>
    /// Attempts to submit the document for review based on the current state and user role.
    /// </summary>
    /// <param name="userRole">The role of the user attempting the action.</param>
    /// <exception cref="InvalidStateTransitionException">Thrown when the current state doesn't support submission for review.</exception>
    /// <exception cref="UnauthorizedActionException">Thrown when the user lacks permission.</exception>
    public void SubmitForReview(UserRoles userRole)
    {
        if (_currentState is ISubmittable state)
        {
            state.SubmitForReview(userRole);
        }
        else
        {
            throw new InvalidStateTransitionException(
                $"Cannot submit document for review in {CurrentStateType} state."
            );
        }
    }
    
    /// <summary>
    /// Attempts to publish the document based on the current state and user role.
    /// </summary>
    /// <param name="userRole">The role of the user attempting the action.</param>
    /// <exception cref="InvalidStateTransitionException">Thrown when the current state doesn't support publishing.</exception>
    /// <exception cref="UnauthorizedActionException">Thrown when the user lacks permission.</exception>
    public void Publish(UserRoles userRole)
    {
        if (_currentState is IPublishable state)
        {
            state.Publish(userRole);
        }
        else
        {
            throw new InvalidStateTransitionException(
                $"Cannot publish document in {CurrentStateType} state."
            );
        }
    }
    
    /// <summary>
    /// Attempts to reject the document based on the current state and user role.
    /// </summary>
    /// <param name="userRole">The role of the user attempting the action.</param>
    /// <exception cref="InvalidStateTransitionException">Thrown when the current state doesn't support rejection.</exception>
    /// <exception cref="UnauthorizedActionException">Thrown when the user lacks permission.</exception>
    public void Reject(UserRoles userRole)
    {
        if (_currentState is IRejectable state)
        {
            state.Reject(userRole);
        }
        else
        {
            throw new InvalidStateTransitionException(
                $"Cannot reject document in {CurrentStateType} state."
            );
        }
    }
    
    /// <summary>
    /// Attempts to suspend the document based on the current state and user role.
    /// </summary>
    /// <param name="userRole">The role of the user attempting the action.</param>
    /// <exception cref="InvalidStateTransitionException">Thrown when the current state doesn't support suspension.</exception>
    /// <exception cref="UnauthorizedActionException">Thrown when the user lacks permission.</exception>
    public void Suspend(UserRoles userRole)
    {
        if (_currentState is ISuspendable state)
        {
            state.Suspend(userRole);
        }
        else
        {
            throw new InvalidStateTransitionException(
                $"Cannot suspend document in {CurrentStateType} state. " +
                $"Only Published documents can be suspended."
            );
        }
    }
    
    /// <summary>
    /// Attempts to unsuspend the document based on the current state and user role.
    /// </summary>
    /// <param name="userRole">The role of the user attempting the action.</param>
    /// <exception cref="InvalidStateTransitionException">Thrown when the current state doesn't support republishing.</exception>
    /// <exception cref="UnauthorizedActionException">Thrown when the user lacks permission.</exception>
    public void Republish(UserRoles userRole)
    {
        if (_currentState is IRepublishable state)
        {
            state.Republish(userRole);
        }
        else
        {
            throw new InvalidStateTransitionException(
                $"Cannot unsuspend document in {CurrentStateType} state. " +
                $"Only Suspended documents can be unsuspended."
            );
        }
    }
}