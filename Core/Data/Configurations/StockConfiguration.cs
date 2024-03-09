using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Configurations;
internal class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder
          .HasOne(p => p.Product)
          .WithOne(p => p.Stock)
          .HasForeignKey<Product>(p => p.StockId)
          .OnDelete(DeleteBehavior.Restrict);
    }
}
