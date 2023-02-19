using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindoctorWeb.Areas.Manage.Controllers
{
	[Area("Manage")]
    [Authorize(Roles = "Admin")]
	public class HomeController : Controller
    {
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

    }
}
