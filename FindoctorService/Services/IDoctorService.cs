using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.DoctorVM;

namespace FindoctorService.Services
{
    public interface IDoctorService
    {
        Task<ICollection<Doctor>> GetAllDoctorAsync();
        Task<ICollection<Doctor>> GetAllDoctorIncludeAsync(int? id);
        Task AddDoctorAsync(CreateDoctorVM doctorVM, string userId);
        Task<UpdateDoctorVM> UpdateDoctorAsync(int? id);
        Task UpdateDoctorPostAsync(int? id, UpdateDoctorVM doctorVM);
        Task DeleteDoctorAsync(int? id);
    }
}
