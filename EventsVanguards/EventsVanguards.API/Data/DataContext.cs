using EventsVanguards.API.Controllers;
using EventsVanguards.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsVanguards.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<EventStaff> EventStaffs { get; set; }  
        public DbSet<Register> Registers { get; set; }

        //DbSets
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }

        public DbSet<MeetingSponsor> MeetingSponsors { get; set; }
        public DbSet<MeetingStaff> MeetingStaffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la clave primaria compuesta para MeetingSponsor
            modelBuilder.Entity<MeetingSponsor>()
                .HasKey(ms => new { ms.IdMeeting, ms.IdSponsor });

            // Configurar la clave primaria compuesta para MeetingStaff
            modelBuilder.Entity<MeetingStaff>()
                .HasKey(ms => new { ms.IdMeeting, ms.IdEventStaff });
        }
    }
}

