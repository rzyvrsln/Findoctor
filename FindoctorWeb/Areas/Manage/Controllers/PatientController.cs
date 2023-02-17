using FindoctorService.Services;
using FindoctorViewModel.Entities.PatientVM;
using Microsoft.AspNetCore.Mvc;

namespace FindoctorWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
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
        public async Task<IActionResult> Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientVM patientVM)
        {
            await patientService.AddPatientAsync(patientVM);
            return RedirectToAction(nameof(Index), "Patient");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            await patientService.DeletePatientAsync(id);
            return RedirectToAction(nameof(Index), "Patient");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            var patients = await patientService.UpdatePatientAsync(id);
            return View(patients);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdatePatientVM patientVM)
        {
            await patientService.UpdatePatientPostAsync(id, patientVM);
            return RedirectToAction(nameof(Index), "Patient");
        }
    }
}
