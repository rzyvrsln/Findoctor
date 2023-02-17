using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.ClinicVm;

namespace FindoctorService.Services
{
    public interface IClinicService
    {
        Task<ICollection<Clinic>> GetAllClinicAsync();
        Task AddClinicAsync(CreateClinicVM clinicVM);
        Task DeleteClinicAsync(int? id);
        Task<UpdateClinicVM> UpdateClinicAsync(int? id);
        Task UpdateClinicPostAsync(int? id, UpdateClinicVM clinicVM);
    }
}
