using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.Configurations;

public class TicketImageConfiguration : IEntityTypeConfiguration<TicketImage>
{
    public void Configure(EntityTypeBuilder<TicketImage> builder)
    {
        builder
            .Property(x => x.Image)
            .IsUnicode(true);
    }
}