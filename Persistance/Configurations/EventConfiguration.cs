using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;

public class EventConfiguration: IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Title).IsRequired();
        builder.Property(e => e.OrganizerId).IsRequired();
        builder.Property(e => e.Date).IsRequired();
        builder.Property(e => e.Time).IsRequired();
    }
}