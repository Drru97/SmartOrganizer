using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartOrganizer.Timetable.Services.Timetable;

namespace SmartOrganizer.Timetable.API.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class TimetableController : Controller
	{
		private readonly ITimetableService _timetableService;

		public TimetableController(ITimetableService timetableService)
		{
			_timetableService = timetableService;
		}

		// GET api/timetable
		[HttpGet]
		public async Task<IActionResult> GetTimetable()
		{
			var query = new TimetableQueryParams();
			var timetable = await _timetableService.GetTimetable(query);

			return Ok(timetable);
		}
	}
}
