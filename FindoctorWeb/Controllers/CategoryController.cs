using FindoctorData.DAL;
using FindoctorService.Services;
using FindoctorViewModel.Entities.PatientVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindoctorWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IDoctorService doctorService;
        private readonly AppDbContext appDbContext;

        public CategoryController(IDoctorService doctorService, AppDbContext appDbContext)
        {
            this.doctorService = doctorService;
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            var doctors = await doctorService.GetAllDoctorIncludeAsync(id);
            return View(doctors);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var doctor = await appDbContext.Doctors.Include(d => d.Category).Include(d => d.Clinic).FirstOrDefaultAsync(d => d.Id == id);
            return View(doctor);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Paymant(int? id,CreatePatientVM patientVM)
        {
            
            return View();
        }
    }
}
