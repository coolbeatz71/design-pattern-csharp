using DesignPatterns.Behavioral.State.GoodExample.Contracts;
using DesignPatterns.Behavioral.State.GoodExample.Enums;
using DesignPatterns.Behavioral.State.GoodExample.Exceptions;
using DesignPatterns.Behavioral.State.GoodExample.States;

namespace DesignPatterns.Behavioral.State.GoodExample;

/// <summary>
/// Context class in the State Pattern: Represents a document and manages its state transitions.
/// The Context maintains a reference to the current state and delegates state-specific behavior to the state objects.
/// This class provides a stable interface for clients while the internal state changes dynamically.
/// 
/// State Pattern Benefits Demonstrated:
/// 1. Eliminates complex conditional statements for state-specific behavior
/// 2. Makes state transitions explicit and controlled
/// 3. Allows easy addition of new states without modifying existing code
/// 4. Encapsulates state-specific logic within state classes
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
    private DocumentStateType CurrentStateType => _currentState.StateType;
    
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