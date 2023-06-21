using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystemAdrienne.EntityFrameworkCore
{
    public static class LibrarySystemAdrienneDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LibrarySystemAdrienneDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LibrarySystemAdrienneDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
