namespace DesignPatterns.Behavioral.State.GoodExample.Exceptions;

/// <summary>
/// Exception thrown when a user lacks permission to perform an action.
/// </summary>
public class UnauthorizedActionException : Exception
{
    /// <summary>
    /// Initializes a new instance of the UnauthorizedActionException class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public UnauthorizedActionException(string message) : base(message) { }
}