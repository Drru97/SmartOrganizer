using Microsoft.AspNetCore.Mvc;
using SmartOrganizer.Timetable.Services.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartOrganizer.Timetable.Domain.Models;

namespace SmartOrganizer.Timetable.API.Controllers
{
	/// <inheritdoc />
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class AppointmentController : Controller
	{
		private readonly IAppointmentService _appointmentService;

		/// <summary>
		/// Creates new instance of controller.
		/// </summary>
		/// <param name="appointmentService"></param>
		public AppointmentController(IAppointmentService appointmentService)
		{
			_appointmentService = appointmentService;
		}

		// GET: api/appointment
		/// <summary>
		/// Returns collection of appointments.
		/// </summary>
		/// <returns>Collection of appointments</returns>
		/// <response code="200">Returns collection of appointments</response>
		/// <response code="204">No appointments in the sequence</response>
		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Appointment>), 200)]
		[ProducesResponseType(typeof(NoContentResult), 204)]
		public async Task<IActionResult> GetAppointments()
		{
			var data = await _appointmentService.GetAppointments(null, null);

			if (!data.Any())
			{
				return NoContent();
			}

			return Ok(data);
		}

		// GET: api/appointment/5
		/// <summary>
		/// Returns appointment with specified id.
		/// </summary>
		/// <param name="id">Appointment id</param>
		/// <returns>Single appointment with specified id</returns>
		/// <response code="200">Returns appointment with specified id</response>
		/// <response code="400">If id is less than zero</response>
		/// <response code="404">If appointment not exists</response>
		[HttpGet("{id}")]
		[ProducesResponseType(typeof(Appointment), 200)]
		[ProducesResponseType(typeof(BadRequestResult), 400)]
		[ProducesResponseType(typeof(NotFoundResult), 404)]
		public async Task<IActionResult> GetAppointment(int id)
		{
			if (id < 0)
			{
				return BadRequest();
			}

			var appointment = await _appointmentService.GetAppointment(id);

			if (appointment == null)
			{
				return NotFound();
			}

			return Ok(appointment);
		}

		// POST: api/appointment
		/// <summary>
		/// Creates new appointment.
		/// </summary>
		/// <param name="appointment"></param>
		/// <returns>A newly-created appointment</returns>
		/// <response code="201">Returns the newly-created item</response>
		/// <response code="400">If the item is null</response>
		[HttpPost]
		[ProducesResponseType(typeof(Appointment), 201)]
		[ProducesResponseType(typeof(BadRequestResult), 400)]
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
				EndDate = appointment.EndDate
			};

			await _appointmentService.AddAppointment(item);

			return CreatedAtAction(nameof(GetAppointment), new { id = item.Id }, null);
		}

		// PUT: api/appointment
		/// <summary>
		/// Updates existing appointment.
		/// </summary>
		/// <param name="appointment">Item to update</param>
		/// <returns>Updated appointment</returns>
		/// <response code="201">Returns an updated item</response>
		/// <response code="400">If item is null</response>
		/// <response code="404">If appointment not exists</response>
		[HttpPut]
		[ProducesResponseType(typeof(Appointment), 201)]
		[ProducesResponseType(typeof(BadRequestResult), 400)]
		[ProducesResponseType(typeof(NotFoundResult), 404)]
		public async Task<IActionResult> Put([FromBody]Appointment appointment)
		{
			if (appointment == null)
			{
				return BadRequest();
			}

			var item = await _appointmentService.UpdateAppointment(appointment);

			if (item == null)
			{
				return NotFound();
			}

			item.Title = appointment.Title;
			item.Description = appointment.Description;
			item.Location = appointment.Location;
			item.StartDate = appointment.StartDate;
			item.EndDate = appointment.EndDate;

			return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, null);
		}

		// DELETE: api/appointment/5
		/// <summary>
		/// Deletes an appointment.
		/// </summary>
		/// <param name="id">Appointment's id</param>
		/// <returns>Status code</returns>
		/// <response code="204">If item deleted successfully</response>
		/// <response code="400">If id is less than zero</response>
		/// <response code="404">If appointment not exists</response>
		[HttpDelete("{id}")]
		[ProducesResponseType(typeof(NoContentResult), 204)]
		[ProducesResponseType(typeof(BadRequestResult), 400)]
		[ProducesResponseType(typeof(NotFoundResult), 404)]
		public async Task<IActionResult> Delete(int id)
		{
			if (id < 0)
			{
				return BadRequest();
			}

			var item = await _appointmentService.GetAppointment(id);

			if (item == null)
			{
				return NotFound();
			}

			await _appointmentService.DeleteAppointment(item.Id);

			return NoContent();
		}
	}
}
