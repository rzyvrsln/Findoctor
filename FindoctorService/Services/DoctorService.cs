using FindoctorData.UnitOfWorks;
using FindoctorEntity.Entities;

namespace FindoctorService.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ICollection<Doctor>> GetDoctorAsync()
        {
            return await unitOfWork.GetRepository<Doctor>().GetAllAsync();
        }
    }
}
