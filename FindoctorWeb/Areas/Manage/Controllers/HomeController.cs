using Microsoft.AspNetCore.Mvc;

namespace FindoctorWeb.Areas.Manage.Controllers
{
	[Area("Manage")]
	public class HomeController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
	}
}
