using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibrarySystemAdrienne.Configuration;

namespace LibrarySystemAdrienne.Web.Host.Startup
{
    [DependsOn(
       typeof(LibrarySystemAdrienneWebCoreModule))]
    public class LibrarySystemAdrienneWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LibrarySystemAdrienneWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibrarySystemAdrienneWebHostModule).GetAssembly());
        }
    }
}
