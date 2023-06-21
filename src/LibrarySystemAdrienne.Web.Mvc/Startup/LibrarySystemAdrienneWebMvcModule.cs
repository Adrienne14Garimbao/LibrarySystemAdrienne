using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibrarySystemAdrienne.Configuration;

namespace LibrarySystemAdrienne.Web.Startup
{
    [DependsOn(typeof(LibrarySystemAdrienneWebCoreModule))]
    public class LibrarySystemAdrienneWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LibrarySystemAdrienneWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<LibrarySystemAdrienneNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibrarySystemAdrienneWebMvcModule).GetAssembly());
        }
    }
}
