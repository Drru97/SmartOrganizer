using Microsoft.EntityFrameworkCore;
using SmartOrganizer.Timetable.API.Infrastructure.EntityConfiguration;
using SmartOrganizer.Timetable.API.Models;

namespace SmartOrganizer.Timetable.API.Infrastructure
{
    public class TimetableContext : DbContext
    {
        public TimetableContext(DbContextOptions<TimetableContext> options) : base(options)
        {
            // TODO: additional logic in here
        }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppointmentEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
