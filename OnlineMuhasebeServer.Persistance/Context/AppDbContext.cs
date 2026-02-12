using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.AppEntites;
using OnlineMuhasebeServer.Domain.AppEntites.Identity;

namespace OnlineMuhasebeServer.Persistance.Context
{
    public sealed class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<UserAndCompanyRelationship> UserAndCompanyRelationships { get; set; }
    }
}
