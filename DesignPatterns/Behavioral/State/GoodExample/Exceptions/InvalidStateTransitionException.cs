namespace DesignPatterns.Behavioral.State.GoodExample.Exceptions;

/// <summary>
/// Exception thrown when an invalid state transition is attempted.
/// </summary>
public class InvalidStateTransitionException : Exception
{
    /// <summary>
    /// Initializes a new instance of the InvalidStateTransitionException class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public InvalidStateTransitionException(string message) : base(message) { }
}