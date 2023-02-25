using FindoctorService.Services;
using FindoctorViewModel.Entities.PatientVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindoctorWeb.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles = "Doctor")]
    public class PatientController : Controller
    {
        private readonly IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var patients = await patientService.GetAllPatientAsync();
            return View(patients);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            await patientService.DeletePatientAsync(id);
            return RedirectToAction(nameof(Index), "Patient");
        }


    }
}
