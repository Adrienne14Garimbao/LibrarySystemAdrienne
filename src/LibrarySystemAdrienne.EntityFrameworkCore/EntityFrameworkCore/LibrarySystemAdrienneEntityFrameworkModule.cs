using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using LibrarySystemAdrienne.EntityFrameworkCore.Seed;

namespace LibrarySystemAdrienne.EntityFrameworkCore
{
    [DependsOn(
        typeof(LibrarySystemAdrienneCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class LibrarySystemAdrienneEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<LibrarySystemAdrienneDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        LibrarySystemAdrienneDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        LibrarySystemAdrienneDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibrarySystemAdrienneEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
