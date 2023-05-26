using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;

public class OrganizerConfiguration:IEntityTypeConfiguration<Organizer>
{
    public void Configure(EntityTypeBuilder<Organizer> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Name).IsRequired();
        builder
            .HasMany(e => e.Events)
            .WithOne(c => c.Organizer)
            .HasForeignKey(o => o.OrganizerId);
    }
}