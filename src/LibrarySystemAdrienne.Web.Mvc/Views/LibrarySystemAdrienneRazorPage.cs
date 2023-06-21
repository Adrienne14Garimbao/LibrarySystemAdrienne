using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace LibrarySystemAdrienne.Web.Views
{
    public abstract class LibrarySystemAdrienneRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected LibrarySystemAdrienneRazorPage()
        {
            LocalizationSourceName = LibrarySystemAdrienneConsts.LocalizationSourceName;
        }
    }
}
