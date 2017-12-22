using System.Collections.Generic;
using SmartOrganizer.Timetable.API.Models;

namespace SmartOrganizer.Timetable.API.ViewModels
{
    public class AppointmentsViewModel
    {
        public ICollection<Appointment> Appointments { get; }

        public AppointmentsViewModel(Appointment appointment)
        {
            Appointments = new List<Appointment> { appointment };
        }

        public AppointmentsViewModel(ICollection<Appointment> data)
        {
            Appointments = data;
        }
    }
}
