using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Core.Data.Configurations;

public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder
            .ToTable("Managers");

        builder
            .HasMany(p => p.Brands)
            .WithOne(p => (Manager)p.User!)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(p => p.CarouselImages)
            .WithOne(p => (Manager)p.User!)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(p => p.Catalogs)
            .WithOne(p => (Manager)p.User!)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(p => p.CatalogSpecificDiscounts)
            .WithOne(p => (Manager)p.User!)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(p => p.Products)
            .WithOne(p => (Manager)p.User!)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(p => p.ProductSpecificDiscounts)
            .WithOne(p => (Manager)p.User!)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(p => p.Stocks)
            .WithOne(p => (Manager)p.User!)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
