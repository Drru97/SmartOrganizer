using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartOrganizer.Timetable.API.Infrastructure;
using SmartOrganizer.Timetable.API.Models;

namespace SmartOrganizer.Timetable.API
{
    public class TimetableContextSeed
    {
        public async Task SeedAsync(TimetableContext context)
        {
            if (!context.Appointments.Any())
            {
                await context.Appointments.AddRangeAsync(GetAppointments());
                await context.SaveChangesAsync();
            }
        }

        private IEnumerable<Appointment> GetAppointments()
        {
            return new List<Appointment>
            {
                new Appointment
                {
                    Title = ".NET Community Meeting",
                    Description = "Meet and discuss general questions about Lviv .NET Community",
                    Location = "Львів, Олени Степанівни, 45",
                    CreationDate = DateTime.Now,
                    StartDate = new DateTime(2018, 3, 14, 18, 30, 0),
                    EndDate = new DateTime(2018, 3, 14, 22, 0, 0)
                },
                new Appointment
                {
                    Title = "Beer Party",
                    Description = "Drink beer (or maybe something stronger) and talk about the life",
                    Location = "Львів, Achtung Lemberg",
                    CreationDate = DateTime.Now,
                    StartDate = new DateTime(2017, 12, 22, 19, 0, 0),
                    EndDate = new DateTime(2017, 12, 22, 21, 30, 0)
                },
                new Appointment
                {
                    Title = "Carpathians Mountains Trip",
                    Description = "Go to the Carpathians and have a rest",
                    Location = "Славське, Архангельського, 22",
                    CreationDate = DateTime.Now,
                    StartDate = new DateTime(2018, 1, 25, 12, 0, 0),
                    EndDate = new DateTime(2018, 1, 28, 18, 0, 0)
                }
            };
        }
    }
}
