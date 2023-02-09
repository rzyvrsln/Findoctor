using FindoctorEntity.Entities;

namespace FindoctorService.Services
{
    public interface IDoctorService
    {
        Task<ICollection<Doctor>> GetDoctorAsync();
    }
}
