using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibrarySystemAdrienne.Configuration;
using LibrarySystemAdrienne.EntityFrameworkCore;
using LibrarySystemAdrienne.Migrator.DependencyInjection;

namespace LibrarySystemAdrienne.Migrator
{
    [DependsOn(typeof(LibrarySystemAdrienneEntityFrameworkModule))]
    public class LibrarySystemAdrienneMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public LibrarySystemAdrienneMigratorModule(LibrarySystemAdrienneEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(LibrarySystemAdrienneMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                LibrarySystemAdrienneConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibrarySystemAdrienneMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
