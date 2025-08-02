using DesignPatterns.Behavioral.State.GoodExample.Contracts;
using DesignPatterns.Behavioral.State.GoodExample.Enums;

namespace DesignPatterns.Behavioral.State.GoodExample.States;

/// <summary>
/// Concrete State: Represents a document in the Rejected state within the State Pattern.
/// State-specific behavior: Rejected documents are in a terminal state with no available transitions.
/// Implements Interface Segregation Principle by only implementing the base IDocumentState interface.
/// This represents a "dead end" state in the workflow.
/// </summary>
public class RejectedState: IDocumentState
{
    /// <inheritdoc />
    public DocumentStateType StateType => DocumentStateType.Rejected;
}