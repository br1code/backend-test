using EventsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Data
{
    public class EventsDbContext : DbContext
    {
        public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasMany(e => e.EventDates)
                .WithOne(d => d.Event)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventDate> EventDates { get; set; }
    }
}
