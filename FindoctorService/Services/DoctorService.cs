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

        public async Task<UpdateDoctorVM> UpdateDoctorAsync(int? id)
        {
            var doctor = await unitOfWork.GetRepository<Doctor>().GetByIdAsync(id);
            UpdateDoctorVM doctorVM = new UpdateDoctorVM
            {
                Name = doctor.Name,
                Surname = doctor.Surname,
                Phone= doctor.Phone,
                Email= doctor.Email,
                Gender= doctor.Gender,
                StartWorkTime= doctor.StartWorkTime,
                StopWorkTime= doctor.StopWorkTime,
                CategoryId=doctor.CategoryId,
                ClinicId = doctor.ClinicId
            };
            return doctorVM;
        }

        public async Task UpdateDoctorPostAsync(int? id, UpdateDoctorVM doctorVM)
        {
            var doctorId = await unitOfWork.GetRepository<Doctor>().GetByIdAsync(id);

            IFormFile file = doctorVM.Image;
            string fileName = Guid.NewGuid() + file.FileName;
            using var stream = new FileStream(Path.Combine(environment.WebRootPath, "assets", "img", "doctor", fileName), FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();

            doctorId.Name = doctorVM.Name;
            doctorId.Surname = doctorVM.Surname;
            doctorId.Phone = doctorVM.Phone;
            doctorId.Email = doctorVM.Email;
            doctorId.Gender = doctorVM.Gender;
            doctorId.StartWorkTime = doctorVM.StartWorkTime;
            doctorId.StopWorkTime = doctorVM.StopWorkTime;
            doctorId.CategoryId = doctorVM.CategoryId;
            doctorId.ClinicId = doctorVM.ClinicId;

            await unitOfWork.GetRepository<Doctor>().UpdateAsync(doctorId);
            await unitOfWork.SaveChangeAsync();

        }
    }
}
