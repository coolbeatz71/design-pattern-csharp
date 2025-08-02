using DesignPatterns.Behavioral.State.GoodExample.Contracts;
using DesignPatterns.Behavioral.State.GoodExample.Enums;

namespace DesignPatterns.Behavioral.State.GoodExample.States;

public class RepublishedState: IDocumentState
{
    /// <inheritdoc />
    public DocumentStateType StateType => DocumentStateType.Republished;
}