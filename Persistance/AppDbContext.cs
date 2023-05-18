using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<EventSpeaker> EventSpeakers { get; set; }
        public DbSet<Speaker> Speakers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Event>().HasKey(e => e.Id);
            modelBuilder.Entity<Speaker>().HasKey(s => s.Id);
            modelBuilder.Entity<Event>()
                .HasMany(s => s.Speakers)
                .WithMany(e => e.Events)
                .UsingEntity<EventSpeaker>();
            modelBuilder.Entity<Organizer>().HasKey(o => o.Id);
            modelBuilder.Entity<Organizer>()
                .HasMany(e => e.Events)
                .WithOne(c => c.Organizer)
                .HasForeignKey(o => o.OrganizerId);
            modelBuilder.Entity<EventSpeaker>()
                .HasKey(c => new { c.EventId, c.SpeakerId });
        }
    }
}
