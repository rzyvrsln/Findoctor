using FindoctorData.DAL;
using FindoctorEntity.Entities;
using FindoctorService.Services;
using FindoctorViewModel.Entities.ClinicVm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FindoctorWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ClinicController : Controller
    {
        private readonly IClinicService clinicService;
        private readonly AppDbContext dbContext;

        public ClinicController(IClinicService clinicService, AppDbContext dbContext)
        {
            this.clinicService = clinicService;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clinics = await clinicService.GetAllClinicAsync();
            return View(clinics);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(dbContext.Categories, nameof(Category.Id), nameof(Category.Name));
            return View();
        }

            [HttpPost]
        public async Task<IActionResult> Create(CreateClinicVM clinicVM)
        {
            await clinicService.AddClinicAsync(clinicVM);
            return RedirectToAction(nameof(Index), "Clinic");
        }
    }
}
