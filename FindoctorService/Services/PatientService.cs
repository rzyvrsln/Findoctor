using FindoctorData.UnitOfWorks;
using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.PatientVM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FindoctorService.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment environment;

        public PatientService(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            this.unitOfWork = unitOfWork;
            this.environment = environment;
        }

        public async Task AddPatientAsync(CreatePatientVM patientVM)
        {
            IFormFile file = patientVM.Image;
            string fileName = Guid.NewGuid() + file.FileName;
            using var stream = new FileStream(Path.Combine(environment.WebRootPath, "assets", "img", "patient", fileName), FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();

            Patient patient = new Patient
            {
                Name = patientVM.Name,
                Surname = patientVM.Surname,
                Email = patientVM.Email,
                Gender = patientVM.Gender,
                İmageUrl = fileName
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

        public async Task<UpdatePatientVM> UpdatePatientAsync(int? id)
        {
            var patientId = await unitOfWork.GetRepository<Patient>().GetByIdAsync(id);
            UpdatePatientVM patientVM = new UpdatePatientVM
            {
                Name = patientId.Name,
                Surname = patientId.Surname,
                Email = patientId.Email,
                Gender = patientId.Gender,
            };

            return patientVM;
        }

        public async Task UpdatePatientPostAsync(int? id, UpdatePatientVM patientVM)
        {
            var patientOne = await unitOfWork.GetRepository<Patient>().GetByIdAsync(id);
            IFormFile file = patientVM.Image;
            string fileName = Guid.NewGuid() + file.FileName;
            using var stream = new FileStream(Path.Combine(environment.WebRootPath, "assets", "img", "patient", fileName), FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();

            patientOne.Name = patientVM.Name;
            patientOne.Surname = patientVM.Surname;
            patientOne.Email = patientVM.Email;
            patientOne.Gender = patientVM.Gender;
            patientOne.İmageUrl = fileName;

            await unitOfWork.GetRepository<Patient>().UpdateAsync(patientOne);
            await unitOfWork.SaveChangeAsync();

        }
    }
}
