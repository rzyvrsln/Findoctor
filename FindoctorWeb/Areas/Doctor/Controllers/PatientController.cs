using FindoctorData.DAL;
using FindoctorEntity.Entities;
using FindoctorService.Services;
using FindoctorViewModel.Entities.PatientVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Terminal;

namespace FindoctorWeb.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles = "Doctor")]
    public class PatientController : Controller
    {
        private readonly IPatientService patientService;
        private readonly AppDbContext appDbContext;

        public PatientController(IPatientService patientService, AppDbContext appDbContext)
        {
            this.patientService = patientService;
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var patients = await patientService.GetAllPatientAsync();
            var patients = await appDbContext.Patients.Where(p => p.Name != null).Include(p => p.DoctorPatients).ToListAsync();
            return View(patients);
        }

        [HttpGet]
        public async Task<IActionResult> Comfirm(int? pasientId)
        {
            return RedirectToAction(nameof(ComfirmTwo), new RouteValueDictionary(new { Controller = "Patient", Action = "ComfirmTwo", patientId = pasientId }));
        }

        [HttpPost]
        public async Task<IActionResult> ComfirmTwo(int? pasientId)
        {
            var patient = await appDbContext.Patients.FirstOrDefaultAsync(p => p.Id == pasientId);
            Patient pasient = new Patient
            {
                Name = patient.Name,
                Surname = patient.Surname,
                Email = patient.Email,
                Gender = patient.Gender,
                CreatedAt = patient.CreatedAt,
                Paymant = patient.Paymant,
                Time = patient.Time,
                Phone = patient.Phone
            };
            await appDbContext.Patients.AddAsync(pasient);
            await appDbContext.SaveChangesAsync();
            await patientService.DeletePatientAsync(pasientId - 1);
            var doctorPatient = await appDbContext.DoctorPatients.FirstOrDefaultAsync(d => d.PatientId == patient.Id);
            if (doctorPatient is not null)
            {
                DoctorPatient newDoctorPatient = new DoctorPatient
                {
                    PatientId = doctorPatient.PatientId,
                    DoctorId = doctorPatient.Doctor.Id
                };
                appDbContext.DoctorPatients.Update(newDoctorPatient);
                await appDbContext.SaveChangesAsync();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            await patientService.DeletePatientAsync(id);
            return RedirectToAction(nameof(Index), "Patient");
        }


    }
}
