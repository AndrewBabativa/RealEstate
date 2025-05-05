using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Entities;

namespace RealEstate.Infrastructure.Persistence
{
    public class RealEstateDbContext : DbContext
    {
        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options)
            : base(options) { }

        public DbSet<OwnerEntity> Owners => Set<OwnerEntity>();
        public DbSet<PropertyEntity> Properties => Set<PropertyEntity>();
        public DbSet<PropertyImageEntity> PropertyImages => Set<PropertyImageEntity>();
        public DbSet<PropertyTraceEntity> PropertyTraces => Set<PropertyTraceEntity>();
        public DbSet<UserEntity> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<OwnerEntity>(entity =>
            {
                entity.HasKey(o => o.OwnerId);
                entity.Property(o => o.Name).IsRequired().HasMaxLength(100);
                entity.Property(o => o.Address).HasMaxLength(200);
                entity.Property(o => o.Photo).HasMaxLength(200);
            });

            modelBuilder.Entity<PropertyEntity>(entity =>
            {
                entity.HasKey(p => p.PropertyId);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Address).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
                entity.Property(p => p.CodeInternal).HasMaxLength(50);
                entity.Property(p => p.Year).HasMaxLength(4);

                entity.HasOne(p => p.Owner)
                      .WithMany(o => o.Properties)
                      .HasForeignKey(p => p.OwnerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PropertyImageEntity>(entity =>
            {
                entity.HasKey(i => i.PropertyImageId);
                entity.Property(i => i.Url).IsRequired();
                entity.Property(i => i.Enabled).IsRequired();

                entity.HasOne(i => i.Property)
                      .WithMany(p => p.Images)
                      .HasForeignKey(i => i.PropertyId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PropertyTraceEntity>(entity =>
            {
                entity.HasKey(t => t.PropertyTraceId);
                entity.Property(t => t.Name).IsRequired().HasMaxLength(100);
                entity.Property(t => t.DateSale).IsRequired();
                entity.Property(t => t.Value).IsRequired().HasMaxLength(50);
                entity.Property(t => t.Tax).IsRequired().HasMaxLength(50);

                entity.HasOne(t => t.Property)
                      .WithMany(p => p.Traces)
                      .HasForeignKey(t => t.PropertyId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
