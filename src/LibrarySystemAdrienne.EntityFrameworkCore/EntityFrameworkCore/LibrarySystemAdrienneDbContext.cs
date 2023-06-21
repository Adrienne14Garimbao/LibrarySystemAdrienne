using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LibrarySystemAdrienne.Authorization.Roles;
using LibrarySystemAdrienne.Authorization.Users;
using LibrarySystemAdrienne.MultiTenancy;
using LibrarySystemAdrienne.Entities;

namespace LibrarySystemAdrienne.EntityFrameworkCore
{
    public class LibrarySystemAdrienneDbContext : AbpZeroDbContext<Tenant, Role, User, LibrarySystemAdrienneDbContext>
    {
        public LibrarySystemAdrienneDbContext(DbContextOptions<LibrarySystemAdrienneDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Borrower> Borrowers { get; set; }


    }
}
