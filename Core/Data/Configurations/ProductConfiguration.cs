using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Core.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasIndex(p => new { p.Name });

        builder
            .Property(p => p.Price)
            .HasPrecision(18, 4);

        builder
            .HasOne(p => p.ProductSpecificDiscount)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.ProductSpecificDiscountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
           .HasMany(p => p.Comments)
           .WithOne(p => p.Product)
           .HasForeignKey(p => p.ProductId)
           .OnDelete(DeleteBehavior.Restrict);

        builder
          .HasMany(p => p.OrderDetails)
          .WithOne(p => p.Product)
          .HasForeignKey(p => p.ProductId)
          .OnDelete(DeleteBehavior.Restrict);

        builder
          .HasMany(p => p.ProductImages)
          .WithOne(p => p.Product)
          .HasForeignKey(p => p.ProductId)
          .OnDelete(DeleteBehavior.Restrict);

        builder
          .HasMany(p => p.ShoppingCartItems)
          .WithOne(p => p.Product)
          .HasForeignKey(p => p.ProductId)
          .OnDelete(DeleteBehavior.Restrict);

        builder
          .HasMany(p => p.Favorites)
          .WithOne(p => p.Product)
          .HasForeignKey(p => p.ProductId)
          .OnDelete(DeleteBehavior.Restrict);

        builder
          .HasOne(p => p.Stock)
          .WithOne(p => p.Product)
          .HasForeignKey<Stock>(p => p.ProductId)
          .OnDelete(DeleteBehavior.Restrict);
    }
}