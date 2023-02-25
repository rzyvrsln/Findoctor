using FindoctorService.Services;
using FindoctorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FindoctorWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService categoryService;
        private readonly IDoctorService doctorService;

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService = null, IDoctorService doctorService = null)
        {
            _logger = logger;
            this.categoryService = categoryService;
            this.doctorService = doctorService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllIncludeAsync();
            ViewBag.Doctors = await doctorService.GetAllDoctorAsync();
            return View(categories);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}