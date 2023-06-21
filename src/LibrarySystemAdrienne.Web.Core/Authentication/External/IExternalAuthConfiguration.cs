using System.Collections.Generic;

namespace LibrarySystemAdrienne.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
