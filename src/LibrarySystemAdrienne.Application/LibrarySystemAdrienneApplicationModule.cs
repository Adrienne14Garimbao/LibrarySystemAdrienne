using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibrarySystemAdrienne.Authorization;

namespace LibrarySystemAdrienne
{
    [DependsOn(
        typeof(LibrarySystemAdrienneCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class LibrarySystemAdrienneApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<LibrarySystemAdrienneAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(LibrarySystemAdrienneApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
