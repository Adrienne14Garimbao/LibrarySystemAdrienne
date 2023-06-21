using System.Collections.Generic;
using LibrarySystemAdrienne.Roles.Dto;

namespace LibrarySystemAdrienne.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}