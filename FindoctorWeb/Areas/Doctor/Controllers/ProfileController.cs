using FindoctorData.DAL;
using FindoctorEntity.Entities;
using FindoctorService.Services;
using FindoctorViewModel.Entities.DoctorVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FindoctorWeb.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles = "Doctor")]
    public class ProfileController : Controller
    {
        private readonly IDoctorService doctorService;
        private readonly AppDbContext dbContext;

        public ProfileController(IDoctorService doctorService, AppDbContext dbContext)
        {
            this.doctorService = doctorService;
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> ViewProfile()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var docId = await dbContext.Doctors.FirstOrDefaultAsync(d => d.UserId == userid);
            if (docId is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var cat = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == docId.CategoryId);
            var clinic = await dbContext.Clinics.FirstOrDefaultAsync(c => c.Id == docId.ClinicId);
            ViewBag.Category = cat.Name;
            ViewBag.Clinic = clinic.Name;

            return View(docId);
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
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(dbContext.Categories, nameof(Category.Id), nameof(Category.Name));
                ViewBag.Clinics = new SelectList(dbContext.Clinics, nameof(Clinic.Id), nameof(Clinic.Name));
                return View();
            }

            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await doctorService.AddDoctorAsync(doctorVM, userid);

            return RedirectToAction(nameof(ViewProfile), "Profile");
        }

    }
}
