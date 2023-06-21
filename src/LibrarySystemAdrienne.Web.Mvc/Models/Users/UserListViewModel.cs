using System.Collections.Generic;
using LibrarySystemAdrienne.Roles.Dto;

namespace LibrarySystemAdrienne.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
