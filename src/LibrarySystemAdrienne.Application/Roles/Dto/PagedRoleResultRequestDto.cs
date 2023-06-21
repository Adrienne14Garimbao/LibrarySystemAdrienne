using Abp.Application.Services.Dto;

namespace LibrarySystemAdrienne.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

