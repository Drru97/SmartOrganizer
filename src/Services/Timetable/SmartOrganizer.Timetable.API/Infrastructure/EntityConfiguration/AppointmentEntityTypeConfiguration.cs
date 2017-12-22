using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartOrganizer.Timetable.API.Models;

namespace SmartOrganizer.Timetable.API.Infrastructure.EntityConfiguration
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

            builder.Property(p => p.Duration);
        }   
    }
}
