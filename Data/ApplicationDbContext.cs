using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data.Entities;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<DeviceEntity> Device { get; set; }
        public DbSet<MeasurementEntity> Measurement { get; set; }
        public DbSet<TestTypeEntity> TestType { get; set; }
        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<DeviceEntity> Devices { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<UserEntity>()
        //        .HasMany(n => n.MeasurementEntity)
        //        .WithOne(n => n.User)
        //        .HasForeignKey(n => n.Id);

        //    builder.Entity<UserEntity>()
        //        .HasMany(n => n.DeviceEntity)
        //        .WithOne(n => n.User)
        //        .HasForeignKey(n => n.UserId);

        //    builder.Entity<UserEntity>()
        //        .HasOne(n => n.Profiles)
        //        .WithOne(n => n.User)
        //        .HasForeignKey<ProfileEntity>(n => n.UserId);
        //}

    }
}