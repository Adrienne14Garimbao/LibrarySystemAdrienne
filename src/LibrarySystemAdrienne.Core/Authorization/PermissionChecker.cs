using Abp.Authorization;
using LibrarySystemAdrienne.Authorization.Roles;
using LibrarySystemAdrienne.Authorization.Users;

namespace LibrarySystemAdrienne.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
