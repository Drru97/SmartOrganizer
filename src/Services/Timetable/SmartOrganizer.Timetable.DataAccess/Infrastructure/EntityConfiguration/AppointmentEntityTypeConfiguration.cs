using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartOrganizer.Timetable.Domain.Models;

namespace SmartOrganizer.Timetable.DataAccess.Infrastructure.EntityConfiguration
{
	public class AppointmentEntityTypeConfiguration : IEntityTypeConfiguration<Appointment>
	{
		public void Configure(EntityTypeBuilder<Appointment> builder)
		{
			builder.ToTable("Appointment");

			builder.HasKey(k => k.Id);

			builder.Property(p => p.Id)
				.ForSqlServerUseSequenceHiLo("appointment_hilo")
				.IsRequired();

			builder.Property(p => p.Title)
				.HasMaxLength(100);

			builder.Property(p => p.Description)
				.HasMaxLength(1000);

			builder.Property(p => p.CreationDate);

			builder.Property(p => p.Location);

			builder.Property(p => p.StartDate);

			builder.Property(p => p.EndDate);
		}
	}
}
