using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartOrganizer.Timetable.API.Infrastructure;
using SmartOrganizer.Timetable.API.Models;
using SmartOrganizer.Timetable.API.ViewModels;

namespace SmartOrganizer.Timetable.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        private readonly TimetableContext _context;

        public AppointmentController(TimetableContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: api/appointment
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var data = (IQueryable<Appointment>)_context.Appointments;
            var model = new AppointmentsViewModel(await data.ToListAsync());

            if (!model.Appointments.Any())
            {
                return NoContent();
            }

            return Ok(model);
        }

        // GET: api/appointment/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var appointment = await _context.Appointments.SingleOrDefaultAsync(ap => ap.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        // POST: api/appointment
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody]Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest();
            }

            var item = new Appointment
            {
                Title = appointment.Title,
                Description = appointment.Description,
                Location = appointment.Location,
                CreationDate = DateTime.Now,
                StartDate = appointment.StartDate,
                Duration = appointment.Duration
            };

            await _context.Appointments.AddAsync(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAppointment), new { id = item.Id }, null);
        }

        // PUT: api/appointment/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest();
            }

            var item = await _context.Appointments.SingleOrDefaultAsync(ap => ap.Id == appointment.Id);

            if (item == null)
            {
                return NotFound();
            }

            item.Title = appointment.Title;
            item.Description = appointment.Description;
            item.Location = appointment.Location;
            item.StartDate = appointment.StartDate;
            item.Duration = appointment.Duration;

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, null);
        }

        // DELETE: api/appointment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var item = await _context.Appointments.SingleOrDefaultAsync(ap => ap.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
