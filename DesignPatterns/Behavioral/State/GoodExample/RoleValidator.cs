using DesignPatterns.Behavioral.State.GoodExample.Contracts;
using DesignPatterns.Behavioral.State.GoodExample.Enums;

namespace DesignPatterns.Behavioral.State.GoodExample;

public class RoleValidator: IRoleValidator
{
    /// <inheritdoc />
    public bool CanSubmitForReview(UserRoles role)
    {
        return role is UserRoles.Editor or UserRoles.Admin or UserRoles.SuperAdmin;
    }
    
    /// <inheritdoc />
    public bool CanPublish(UserRoles role)
    {
        return role is UserRoles.Moderator or UserRoles.Admin or UserRoles.SuperAdmin;
    }
    
    /// <inheritdoc />
    public bool CanReject(UserRoles role)
    {
        return role is UserRoles.Moderator or UserRoles.Admin or UserRoles.SuperAdmin;
    }
    
    /// <inheritdoc />
    public bool CanSuspend(UserRoles role)
    {
        return role is UserRoles.Admin or UserRoles.SuperAdmin;
    }
    
    /// <inheritdoc />
    public bool CanRepublish(UserRoles role)
    {
        return role is UserRoles.Admin or UserRoles.SuperAdmin;
    }
}