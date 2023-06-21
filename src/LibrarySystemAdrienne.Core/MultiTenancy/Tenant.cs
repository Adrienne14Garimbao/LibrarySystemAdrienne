using Abp.MultiTenancy;
using LibrarySystemAdrienne.Authorization.Users;

namespace LibrarySystemAdrienne.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
