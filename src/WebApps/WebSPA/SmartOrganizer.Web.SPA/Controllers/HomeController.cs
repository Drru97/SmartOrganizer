using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace SmartOrganizer.Web.SPA.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;

        public HomeController(IOptionsSnapshot<AppSettings> settings)
        {
            _settings = settings;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        public IActionResult Configuration()
        {
            return Json(_settings.Value);
        }
    }
}
