using FindoctorData.UnitOfWorks;
using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.ClinicVm;

namespace FindoctorService.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IUnitOfWork unitOfWork;

        public ClinicService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddClinicAsync(CreateClinicVM clinicVM)
        {
            Clinic clinic = new Clinic
            {
                Name = clinicVM.Name,
                Description = clinicVM.Description,
                Location = clinicVM.Location,
                StartWorkTime = clinicVM.StartWorkTime,
                StoptWorkTime = clinicVM.StoptWorkTime,
                CategoryId = clinicVM.CategoryId,
            };
            await unitOfWork.GetRepository<Clinic>().AddAsync(clinic);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteClinicAsync(int? id)
        {
            var clinic = await unitOfWork.GetRepository<Clinic>().GetByIdAsync(id);
            await unitOfWork.GetRepository<Clinic>().DeleteAsync(clinic);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task<ICollection<Clinic>> GetAllClinicAsync()
        {
            await unitOfWork.GetRepository<Category>().GetAllAsync();
            return await unitOfWork.GetRepository<Clinic>().GetAllAsync();
        }
    }
}
