using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace LibrarySystemAdrienne.Localization
{
    public static class LibrarySystemAdrienneLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(LibrarySystemAdrienneConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(LibrarySystemAdrienneLocalizationConfigurer).GetAssembly(),
                        "LibrarySystemAdrienne.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
