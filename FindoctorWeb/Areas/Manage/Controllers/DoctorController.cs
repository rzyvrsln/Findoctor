using FindoctorData.DAL;
using FindoctorEntity.Entities;
using FindoctorService.Extensions;
using FindoctorService.Services;
using FindoctorViewModel.Entities.DoctorVM;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FindoctorWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService doctorService;
        private readonly AppDbContext dbContext;
        private readonly IValidator<FindoctorEntity.Entities.Doctor> validator;

        public DoctorController(IDoctorService doctorService, AppDbContext dbContext, IValidator<FindoctorEntity.Entities.Doctor> validator)
        {
            this.doctorService = doctorService;
            this.dbContext = dbContext;
            this.validator = validator;
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

            if (!ModelState.IsValid)
            {
            //    IFormFile file = doctorVM.Image;
            //    string fileName = Guid.NewGuid() + file.FileName;
                //FindoctorEntity.Entities.Doctor doctor = new FindoctorEntity.Entities.Doctor
                //{
                //    Name = doctorVM.Name,
                //    Surname = doctorVM.Surname,
                //    Phone = doctorVM.Phone,
                //    Email = doctorVM.Email,
                //    Gender = doctorVM.Gender,
                //    //ImageUrl = fileName,
                //    StartWorkTime = doctorVM.StartWorkTime,
                //    StopWorkTime = doctorVM.StopWorkTime,
                //    CategoryId = doctorVM.CategoryId,
                //    ClinicId = doctorVM.ClinicId
                //};
                //var result = await validator.ValidateAsync(doctor);
                //if (!result.IsValid) { result.AddToModelState(this.ModelState);return View(); }
                ViewBag.Categories = new SelectList(dbContext.Categories, nameof(Category.Id), nameof(Category.Name));
                ViewBag.Clinics = new SelectList(dbContext.Clinics, nameof(Clinic.Id), nameof(Clinic.Name));
                return View();
            }
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

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            await doctorService.DeleteDoctorAsync(id);
            return RedirectToAction(nameof(Index), "Doctor");
        }
    }
}
