using FindoctorData.DAL;
using FindoctorEntity.Entities;
using FindoctorService.Services;
using FindoctorViewModel.Entities.DoctorVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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
        public async Task<IActionResult> ViewProfile(string userID)
        {
            var doctors = await doctorService.GetAllDoctorAsync();
            if (dbContext.Doctors.FirstOrDefaultAsync(d => d.UserId == userID) is null)
            {
                return RedirectToAction(nameof(Index));
            }
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
