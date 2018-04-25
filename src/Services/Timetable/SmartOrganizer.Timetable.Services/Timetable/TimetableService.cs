using SmartOrganizer.Timetable.Services.Appointment;
using SmartOrganizer.Timetable.Services.Directions;
using SmartOrganizer.Timetable.Services.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SmartOrganizer.Timetable.Services.Timetable
{
	public class TimetableService : ITimetableService
	{
		private readonly IDirectionsService _directionsService;
		private readonly IAppointmentService _appointmentService;

		public TimetableService(IDirectionsService directionsService, IAppointmentService appointmentService)
		{
			_directionsService = directionsService;
			_appointmentService = appointmentService;
		}

		public async Task<TimetableViewModel> GetTimetable(TimetableQueryParams query)
		{
			var queryParams = BuildAppointmentQueryParams(query);
			var pagingModel = BuildAppointmentPagingModel(query);

			var appointments = await _appointmentService.GetAppointments(queryParams, pagingModel);

			var vm = new TimetableViewModel();

			for (var i = 0; i < appointments.Count() - 1; i++)
			{
				var request = CreateDirectionRequest(appointments.ElementAt(i), appointments.ElementAt(i + 1));

				var response = _directionsService.GetDirections(request);

				var timetableVieItem = GenerateTimetableItem(request, response);
				vm.TimetableViewItems.Add(timetableVieItem);
			}

			return vm;
		}

		private static AppointmentPagingModel BuildAppointmentPagingModel(TimetableQueryParams query)
		{
			var pagingModel = new AppointmentPagingModel
			{
				TakeRecords = query.TakeRecords,
				SkipRecords = query.SkipRecords
			};

			return pagingModel;
		}

		private static AppointmentQueryParams BuildAppointmentQueryParams(TimetableQueryParams query)
		{
			var queryParams = new AppointmentQueryParams
			{
				FromTime = query.StartFrom,
				ByTime = query.EndBy
			};

			return queryParams;
		}

		private static DirectionsRequest CreateDirectionRequest(Domain.Models.Appointment prev, Domain.Models.Appointment next)
		{
			var request = new DirectionsRequest
			{
				Origin = prev.Location,
				Destination = next.Location,
				//	DepartureTime = prev.EndDate,
				ArrivalTime = next.StartDate
			};

			return request;
		}

		private static TimetableViewItem GenerateTimetableItem(DirectionsRequest request, DirectionsResponse response)
		{
			var item = new TimetableViewItem
			{
				Route = response.Route
			};

			return item;
		}
	}
}
