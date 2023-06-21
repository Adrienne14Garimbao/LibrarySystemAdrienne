using Abp.AutoMapper;
using LibrarySystemAdrienne.Sessions.Dto;

namespace LibrarySystemAdrienne.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
