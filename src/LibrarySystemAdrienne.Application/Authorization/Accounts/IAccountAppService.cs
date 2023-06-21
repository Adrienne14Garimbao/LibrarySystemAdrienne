using System.Threading.Tasks;
using Abp.Application.Services;
using LibrarySystemAdrienne.Authorization.Accounts.Dto;

namespace LibrarySystemAdrienne.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
