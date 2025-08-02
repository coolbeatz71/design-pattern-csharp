namespace DesignPatterns.Behavioral.State.BadExample
{
    /// <summary>
    /// Represents the possible lifecycle states of a document.
    /// </summary>
    public enum DocumentStatus
    {
        Draft,
        Moderated,
        Suspended,
        Published
    }
}