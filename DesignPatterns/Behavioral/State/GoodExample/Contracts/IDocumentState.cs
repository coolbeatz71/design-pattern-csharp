using DesignPatterns.Behavioral.State.GoodExample.Enums;

namespace DesignPatterns.Behavioral.State.GoodExample.Contracts;

/// <summary>
/// Base interface for all document states in the State Pattern.
/// Defines the minimum contract that all concrete state classes must implement.
/// Follows the Interface Segregation Principle by only exposing essential state information.
/// </summary>
public interface IDocumentState
{
    /// <summary>
    /// Gets the type of the current state.
    /// </summary>
    DocumentStateType StateType { get; }
}