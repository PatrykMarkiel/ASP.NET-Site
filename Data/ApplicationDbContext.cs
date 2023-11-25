using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data.Entities;

namespace WebApplication3.Data
{
        public class ApplicationDbContext : IdentityDbContext<UserEntity>
    {
        public DbSet<MeasurementEntity> Measurement { get; set; }
        public DbSet<TestTypeEntity> TestType { get; set; }
        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<DeviceEntity> Device { get; set; }
        public DbSet<UserEntity> User { get; set; } 

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<UserEntity>()
             .HasMany(n => n.Measurement)
             .WithOne(n => n.User)
             .HasForeignKey(n => n.UserId);

            builder.Entity<UserEntity>()
           .HasOne(n => n.Profile)
           .WithOne(n => n.User)
           .HasForeignKey<ProfileEntity>(n => n.UserId);

            builder.Entity<UserEntity>()
           .HasMany(n => n.Device)
           .WithOne(n => n.User)
           .HasForeignKey(n => n.UserId);

        }

    }
}