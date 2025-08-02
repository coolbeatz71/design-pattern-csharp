namespace DesignPatterns.Behavioral.State.GoodExample.Enums;

/// <summary>
/// Represents the possible states a document can be in.
/// </summary>
public enum DocumentStateType
{
    Draft,
    Review,
    Published,
    Rejected,
    Suspended,
    Republished
}