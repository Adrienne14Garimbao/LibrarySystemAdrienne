using Abp.Application.Services;
using LibrarySystemAdrienne.MultiTenancy.Dto;

namespace LibrarySystemAdrienne.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

