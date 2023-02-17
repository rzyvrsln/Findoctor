using FindoctorData.DAL;
using FindoctorEntity.Entities;
using FindoctorService.Services;
using FindoctorViewModel.Entities.DoctorVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FindoctorWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService doctorService;
        private readonly AppDbContext dbContext;

        public DoctorController(IDoctorService doctorService, AppDbContext dbContext)
        {
            this.doctorService = doctorService;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var doctors = await doctorService.GetAllDoctorAsync();
            return View(doctors);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(dbContext.Categories, nameof(Category.Id), nameof(Category.Name));
            ViewBag.Clinics = new SelectList(dbContext.Clinics, nameof(Clinic.Id), nameof(Clinic.Name));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDoctorVM doctorVM)
        {
            await doctorService.AddDoctorAsync(doctorVM);
            return RedirectToAction(nameof(Index), "Doctor");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Categories = new SelectList(dbContext.Categories, nameof(Category.Id), nameof(Category.Name));
            ViewBag.Clinics = new SelectList(dbContext.Clinics, nameof(Clinic.Id), nameof(Clinic.Name));
            var doctors = await doctorService.UpdateDoctorAsync(id);
            return View(doctors);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdateDoctorVM doctorVM)
        {
            await doctorService.UpdateDoctorPostAsync(id, doctorVM);
            return RedirectToAction(nameof(Index), "Doctor");
        }
    }
}
