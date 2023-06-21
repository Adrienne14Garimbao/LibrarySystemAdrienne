using Abp.AutoMapper;
using LibrarySystemAdrienne.Roles.Dto;
using LibrarySystemAdrienne.Web.Models.Common;

namespace LibrarySystemAdrienne.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
