using FindoctorData.DAL;
using FindoctorData.UnitOfWorks;
using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.PatientVM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FindoctorService.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment environment;
        private readonly AppDbContext appDbContext;

        public PatientService(IUnitOfWork unitOfWork, IWebHostEnvironment environment, AppDbContext appDbContext)
        {
            this.unitOfWork = unitOfWork;
            this.environment = environment;
            this.appDbContext = appDbContext;
        }

        public async Task AddPatientAsync(CreatePatientVM patientVM)
        {
            #region For Image
            //IFormFile file = patientVM.Image;
            //string fileName = Guid.NewGuid() + file.FileName;
            //using var stream = new FileStream(Path.Combine(environment.WebRootPath, "assets", "img", "patient", fileName), FileMode.Create);
            //await file.CopyToAsync(stream);
            //await stream.FlushAsync();
            #endregion

            Patient patient = new Patient
            {
                Name = patientVM.Name,
                Surname = patientVM.Surname,
                Email = patientVM.Email,
                Gender = patientVM.Gender,
                Time = patientVM.Time,
                Paymant = patientVM.Paymant,
                Phone = patientVM.Phone
            };

            await unitOfWork.GetRepository<Patient>().AddAsync(patient);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task DeletePatientAsync(int? id)
        {
            var patientId = await unitOfWork.GetRepository<Patient>().GetByIdAsync(id);
            string filePath = Path.Combine(environment.WebRootPath, "assets", "img", "patient", patientId.İmageUrl);
            File.Delete(filePath);
            await unitOfWork.GetRepository<Patient>().DeleteAsync(patientId);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task<ICollection<Patient>> GetAllPatientAsync()
        {
            

            return await unitOfWork.GetRepository<Patient>().GetAllAsync();
        }

        public async Task RemoveNullTables()
        {
            var nullNameItems = await appDbContext.Patients.Where(item => item.Name == null || item.Surname == null || item.Email == null || item.Gender == null).ToListAsync();
            foreach (var item in nullNameItems)
            {
                appDbContext.Patients.Remove(item);
                await unitOfWork.SaveChangeAsync();
            }
        }

        public async Task<UpdatePatientVM> UpdatePatientAsync(int? id)
        {
            var patientId = await unitOfWork.GetRepository<Patient>().GetByIdAsync(id);
            UpdatePatientVM patientVM = new UpdatePatientVM
            {
                Name = patientId.Name,
                Surname = patientId.Surname,
                Email = patientId.Email,
                Gender = patientId.Gender,
                Time = patientId.Time,
                Paymant = patientId.Paymant,
            };

            return patientVM;
        }

        public async Task UpdatePatientPostAsync(int? id, UpdatePatientVM patientVM)
        {
            var patientOne = await unitOfWork.GetRepository<Patient>().GetByIdAsync(id);
            //IFormFile file = patientVM.Image;
            //string fileName = Guid.NewGuid() + file.FileName;
            //using var stream = new FileStream(Path.Combine(environment.WebRootPath, "assets", "img", "patient", fileName), FileMode.Create);
            //await file.CopyToAsync(stream);
            //await stream.FlushAsync();

            patientOne.Name = patientVM.Name;
            patientOne.Surname = patientVM.Surname;
            patientOne.Email = patientVM.Email;
            patientOne.Gender = patientVM.Gender;
            patientOne.Time = patientVM.Time;
            patientOne.Paymant = patientVM.Paymant;
            patientOne.Phone = patientVM.Phone;
            await unitOfWork.GetRepository<Patient>().UpdateAsync(patientOne);
            await unitOfWork.SaveChangeAsync();

        }
    }
}
