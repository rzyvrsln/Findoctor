using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.PatientVM;

namespace FindoctorService.Services
{
    public interface IPatientService
    {
        Task<ICollection<Patient>> GetAllPatientAsync();
        Task AddPatientAsync(CreatePatientVM patientVM);
        Task DeletePatientAsync(int? id);
        Task<UpdatePatientVM> UpdatePatientAsync(int? id);
        Task UpdatePatientPostAsync(int? id, UpdatePatientVM patientVM);
    }
}
