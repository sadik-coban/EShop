using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.Configurations;

public class CatalogSpecificDiscountConfiguration : IEntityTypeConfiguration<CatalogSpecificDiscount>
{
    public void Configure(EntityTypeBuilder<CatalogSpecificDiscount> builder)
    {
        builder
            .HasIndex(p => p.Name)
            .IsUnique(true);

        builder
            .HasOne(p => p.Catalog)
            .WithOne(p => p.CatalogSpecificDiscount)
            .HasForeignKey<Catalog>(p => p.CatalogSpecificDiscountId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}