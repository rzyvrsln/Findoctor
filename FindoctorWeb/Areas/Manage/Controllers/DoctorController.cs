using FindoctorService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindoctorWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService doctorService;

        public DoctorController(IDoctorService doctorService) => this.doctorService = doctorService;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var doctors = await doctorService.GetDoctorAsync();
            return View(doctors);
        }

        [HttpGet]
        public async Task<IActionResult> Create() => View();
    }
}
