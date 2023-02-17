using FindoctorData.UnitOfWorks;
using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.DoctorVM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FindoctorService.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment environment;

        public DoctorService(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            this.unitOfWork = unitOfWork;
            this.environment = environment;
        }

        public async Task AddDoctorAsync(CreateDoctorVM doctorVM)
        {
            IFormFile file = doctorVM.Image;
            string fileName = Guid.NewGuid() + file.FileName;
            using var stream = new FileStream(Path.Combine(environment.WebRootPath, "assets", "img", "doctor", fileName), FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();

            Doctor doctor = new Doctor
            {
                Name = doctorVM.Name,
                Surname = doctorVM.Surname,
                Phone = doctorVM.Phone,
                Email = doctorVM.Email,
                Gender = doctorVM.Gender,
                StartWorkTime = doctorVM.StartWorkTime,
                StopWorkTime = doctorVM.StopWorkTime,
                CategoryId = doctorVM.CategoryId,
                ClinicId = doctorVM.ClinicId,
                ImageUrl = fileName
            };

            await unitOfWork.GetRepository<Doctor>().AddAsync(doctor);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task<ICollection<Doctor>> GetAllDoctorAsync()
        {
            return await unitOfWork.GetRepository<Doctor>().GetAllAsync();
        }
    }
}
