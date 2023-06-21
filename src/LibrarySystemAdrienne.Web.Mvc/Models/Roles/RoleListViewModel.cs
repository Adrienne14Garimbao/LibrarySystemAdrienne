using System.Collections.Generic;
using LibrarySystemAdrienne.Roles.Dto;

namespace LibrarySystemAdrienne.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
