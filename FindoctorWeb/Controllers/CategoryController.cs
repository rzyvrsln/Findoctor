using FindoctorService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindoctorWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IDoctorService doctorService;

        public CategoryController(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            var doctors = await doctorService.GetAllDoctorIncludeAsync(id);
            return View(doctors);
        }
    }
}
