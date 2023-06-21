using Abp.AspNetCore.Mvc.ViewComponents;

namespace LibrarySystemAdrienne.Web.Views
{
    public abstract class LibrarySystemAdrienneViewComponent : AbpViewComponent
    {
        protected LibrarySystemAdrienneViewComponent()
        {
            LocalizationSourceName = LibrarySystemAdrienneConsts.LocalizationSourceName;
        }
    }
}
