using FindoctorData.DAL;
using FindoctorData.UnitOfWorks;
using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.DoctorVM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FindoctorService.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment environment;
        private readonly AppDbContext appDbContext;

        public DoctorService(IUnitOfWork unitOfWork, IWebHostEnvironment environment, AppDbContext appDbContext)
        {
            this.unitOfWork = unitOfWork;
            this.environment = environment;
            this.appDbContext = appDbContext;
        }

        public async Task AddDoctorAsync(CreateDoctorVM doctorVM, string userId)
        {
            IFormFile file = doctorVM.Image;
            string fileName = Guid.NewGuid() + file.FileName;
            using var stream = new FileStream(Path.Combine(environment.WebRootPath, "assets", "img", "doctor", fileName), FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();

            Doctor doctor = new Doctor
            {
                UserId = userId,
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

        public async Task DeleteDoctorAsync(int? id)
        {
            var doctor = await unitOfWork.GetRepository<Doctor>().GetByIdAsync(id);
            string filePath = Path.Combine(environment.WebRootPath, "assets", "img", "doctor", doctor.ImageUrl);
            File.Delete(filePath);
            await unitOfWork.GetRepository<Doctor>().DeleteAsync(doctor);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task<ICollection<Doctor>> GetAllDoctorAsync()
        {
            return await unitOfWork.GetRepository<Doctor>().GetAllAsync();
        }

        public async Task<ICollection<Doctor>> GetAllDoctorIncludeAsync(int? id)
        {
            var categories = await appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (categories is not null)
            {
                return await appDbContext.Doctors.Where(d => d.CategoryId == categories.Id).Include(d => d.Category).Include(d => d.Clinic).ToListAsync();
            }
            return null;
        }

        public async Task<UpdateDoctorVM> UpdateDoctorAsync(int? id)
        {
            var doctor = await unitOfWork.GetRepository<Doctor>().GetByIdAsync(id);
            UpdateDoctorVM doctorVM = new UpdateDoctorVM
            {
                Name = doctor.Name,
                Surname = doctor.Surname,
                Phone = doctor.Phone,
                Email = doctor.Email,
                Gender = doctor.Gender,
                StartWorkTime = doctor.StartWorkTime,
                StopWorkTime = doctor.StopWorkTime,
                CategoryId = doctor.CategoryId,
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
