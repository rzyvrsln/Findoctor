using FindoctorData.DAL;
using FindoctorEntity.Entities;
using FindoctorService.Services;
using FindoctorViewModel.Entities.DoctorPatientCombinedVM;
using FindoctorViewModel.Entities.PatientVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using Stripe.FinancialConnections;

namespace FindoctorWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IDoctorService doctorService;
        private readonly IPatientService patientService;
        private readonly AppDbContext appDbContext;

        public CategoryController(IDoctorService doctorService, AppDbContext appDbContext, IPatientService patientService = null)
        {
            this.doctorService = doctorService;
            this.appDbContext = appDbContext;
            this.patientService = patientService;
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
            var doctorView = await appDbContext.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            var viewCount = doctorView.View++;
            Doctor doctorV = new Doctor
            {
                Name = doctorView.Name,
                Surname = doctorView.Surname,
                Phone = doctorView.Phone,
                Email = doctorView.Email,
                Gender = doctorView.Gender,
                ImageUrl = doctorView.ImageUrl,
                StartWorkTime = doctorView.StartWorkTime,
                StopWorkTime = doctorView.StopWorkTime,
                ClinicId = doctorView.ClinicId,
                CategoryId = doctorView.CategoryId,
                CreatedAt = doctorView.CreatedAt,
                UpdatedAt = doctorView.UpdatedAt,
                IsDeleted = doctorView.IsDeleted,
                UserId = doctorView.UserId,
                About = doctorView.About,
                Paymant = doctorView.Paymant,
                IsActive = doctorView.IsActive,
                View = viewCount
            };
            appDbContext.Doctors.Update(doctorView);
            await appDbContext.SaveChangesAsync();

            var doctor = await appDbContext.Doctors.Include(d => d.DoctorPatients).Include(d => d.Category).Include(d => d.Clinic).FirstOrDefaultAsync(d => d.Id == id);
            var doctorPatient = await appDbContext.DoctorPatients.Include(dp=>dp.Patient).FirstOrDefaultAsync(dp=>dp.DoctorId == doctor.Id);
            CombinedViewModel model = new CombinedViewModel
            {
                doctors = doctor,
                doctorPatient = doctorPatient
            };

            

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Detail(int? id, CombinedViewModel model)
        {
            var doctor = await appDbContext.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            Patient patient = new Patient
            {
                Time = model.createPatientVM.Time,
                Paymant = doctor.Paymant
            };

            await appDbContext.Patients.AddAsync(patient);
            await appDbContext.SaveChangesAsync();

            DoctorPatient dp = new DoctorPatient
            {
                DoctorId = doctor.Id,
                PatientId = patient.Id
            };
            await appDbContext.DoctorPatients.AddAsync(dp);
            await appDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Paymant), new RouteValueDictionary(new { Controller = "Category", Action = "Paymant", patientId = patient.Id }));

        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Paymant(int? patientId)
        {
            var patient = await appDbContext.Patients.FirstOrDefaultAsync(p => p.Id == patientId);
            if (patient is null) return BadRequest();
            CombinedViewModel model = new CombinedViewModel
            {
                patients = patient
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Charge(string stripeEmail, string stripeToken, CombinedViewModel model)
        {

            try
            {
                var options = new ChargeCreateOptions
                {
                    Amount = (long)(model.createPatientVM.Paymant * 100),
                    Description = "İstifadəçi ödənişi",
                    Currency = "AZN",
                    ReceiptEmail = stripeEmail,
                    Source = stripeToken
                };
                var service = new ChargeService();
                service.Create(options);
            }
            catch(StripeException ex)
            {
                if (ex.StripeError != null && ex.StripeError.Code == "amount_too_small")
                {
                    throw new Exception($"Charge amount of {model.createPatientVM.Paymant} AZN is below the minimum allowed amount.");
                }
                else
                {
                    return NotFound();
                }
            }
            //await patientService.RemoveNullTables();
            await patientService.AddPatientAsync(model.createPatientVM);
            return RedirectToAction(nameof(SuccessComfirm));
        }

        [HttpGet]
        public async Task<IActionResult> SuccessComfirm() => View();
        
    }
}
