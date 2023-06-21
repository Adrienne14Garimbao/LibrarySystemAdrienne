using System.Threading.Tasks;
using Abp.Application.Services;
using LibrarySystemAdrienne.Sessions.Dto;

namespace LibrarySystemAdrienne.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
