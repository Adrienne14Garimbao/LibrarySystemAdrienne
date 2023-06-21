using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibrarySystemAdrienne.EntityFrameworkCore;
using LibrarySystemAdrienne.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace LibrarySystemAdrienne.Web.Tests
{
    [DependsOn(
        typeof(LibrarySystemAdrienneWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class LibrarySystemAdrienneWebTestModule : AbpModule
    {
        public LibrarySystemAdrienneWebTestModule(LibrarySystemAdrienneEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibrarySystemAdrienneWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(LibrarySystemAdrienneWebMvcModule).Assembly);
        }
    }
}