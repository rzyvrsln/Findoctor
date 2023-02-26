using FindoctorData.DAL;
using FindoctorEntity.Entities;
using FindoctorService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var doctor = appDbContext.Doctors.ToList();
            var patients = await appDbContext.DoctorPatients.Where(dp => dp.Patient.Name != null).Include(dp => dp.Patient).ToListAsync();
            return View(patients);
        }

        [HttpGet]
        public async Task<IActionResult> Comfirm(int? id)
        {
            var patient = await appDbContext.Patients.FirstOrDefaultAsync(p => p.Id == id);
            var doctorPatient = await appDbContext.DoctorPatients.Include(dp => dp.Doctor).Include(dp => dp.Patient).FirstOrDefaultAsync(d => d.PatientId == patient.Id - 1);
            if (doctorPatient is not null)
            {
                DoctorPatient newDoctorPatient = new DoctorPatient
                {
                    PatientId = patient.Id,
                    DoctorId = doctorPatient.Doctor.Id
                };
                appDbContext.DoctorPatients.Add(newDoctorPatient);
                await appDbContext.SaveChangesAsync();
                if (doctorPatient.Patient.Name is null) await patientService.DeletePatientAsync(id - 1);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var patient = await appDbContext.Patients.FirstOrDefaultAsync(p => p.Id == id - 1);
            if(patient.Name is null) await patientService.DeletePatientAsync(id - 1);
            await patientService.DeletePatientAsync(id);
            return RedirectToAction(nameof(Index), "Patient");
        }


    }
}
