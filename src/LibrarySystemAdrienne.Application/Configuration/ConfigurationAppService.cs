using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using LibrarySystemAdrienne.Configuration.Dto;

namespace LibrarySystemAdrienne.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LibrarySystemAdrienneAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
