using Microsoft.AspNetCore.Mvc;

namespace FindoctorWeb.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
