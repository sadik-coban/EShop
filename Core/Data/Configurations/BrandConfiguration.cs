using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder
            .HasIndex(p => p.Name)
            .IsUnique(true);

        builder
            .HasQueryFilter(p => !p.IsSoftDeleted);
    }
}