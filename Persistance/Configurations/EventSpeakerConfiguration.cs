using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;

public class EventSpeakerConfiguration: IEntityTypeConfiguration<EventSpeaker>
{
    public void Configure(EntityTypeBuilder<EventSpeaker> builder)
    {

        builder
            .HasKey(c => new { c.EventId, c.SpeakerId });

        builder
            .HasOne(se => se.Speaker) 
            .WithMany(s => s.EventSpeakers) 
            .HasForeignKey(se => se.SpeakerId); 
 
        builder
            .HasOne(se => se.Event) 
            .WithMany(e => e.EventSpeakers) 
            .HasForeignKey(se => se.EventId);
    }
}