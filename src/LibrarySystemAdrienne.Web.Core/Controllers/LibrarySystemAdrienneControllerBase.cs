using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LibrarySystemAdrienne.Controllers
{
    public abstract class LibrarySystemAdrienneControllerBase: AbpController
    {
        protected LibrarySystemAdrienneControllerBase()
        {
            LocalizationSourceName = LibrarySystemAdrienneConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
