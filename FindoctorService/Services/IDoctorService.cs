using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.DoctorVM;

namespace FindoctorService.Services
{
    public interface IDoctorService
    {
        Task<ICollection<Doctor>> GetAllDoctorAsync();
        Task AddDoctorAsync(CreateDoctorVM doctorVM);
        Task<UpdateDoctorVM> UpdateDoctorAsync(int? id);
        Task UpdateDoctorPostAsync(int? id, UpdateDoctorVM doctorVM);
        Task DeleteDoctorAsync(int? id);
    }
}
