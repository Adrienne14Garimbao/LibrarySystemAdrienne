using System.Threading.Tasks;
using LibrarySystemAdrienne.Configuration.Dto;

namespace LibrarySystemAdrienne.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
