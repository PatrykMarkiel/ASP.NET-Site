using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data.Entities;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<DeviceEntity> Devices { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}