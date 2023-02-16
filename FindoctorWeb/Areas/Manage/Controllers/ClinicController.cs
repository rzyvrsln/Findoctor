using FindoctorService.Services;
using FindoctorViewModel.Entities.ClinicVm;
using Microsoft.AspNetCore.Mvc;

namespace FindoctorWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ClinicController : Controller
    {
        private readonly IClinicService clinicService;

        public ClinicController(IClinicService clinicService)
        {
            this.clinicService = clinicService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clinics = await clinicService.GetAllClinicAsync();
            ViewBag.Categories = clinics.ToList();
            return View(clinics);
        }

        [HttpGet]
        public async Task<IActionResult> Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateClinicVM clinicVM)
        {
            await clinicService.AddClinicAsync(clinicVM);
            return RedirectToAction(nameof(Index), "Clinic");
        }
    }
}
