using FindoctorData.UnitOfWorks;
using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.ClinicVm;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public async Task<UpdateClinicVM> UpdateClinicAsync(int? id)
        {
            var clinicOne = await unitOfWork.GetRepository<Clinic>().GetByIdAsync(id);
             UpdateClinicVM clinicTwo = new UpdateClinicVM
            {
                Name = clinicOne.Name,
                Description = clinicOne.Description,
                Location = clinicOne.Location,
                StartWorkTime = clinicOne.StartWorkTime,
                StoptWorkTime = clinicOne.StoptWorkTime,
                CategoryId = clinicOne.CategoryId
            };
            return clinicTwo;
        }

        public async Task UpdateClinicPostAsync(int? id, UpdateClinicVM clinicVM)
        {
            var clinicOne = await unitOfWork.GetRepository<Clinic>().GetByIdAsync(id);
            if (clinicOne is not null)
            {
                clinicOne.Name = clinicVM.Name;
                clinicOne.Description = clinicVM.Description;
                clinicOne.Location = clinicVM.Location;
                clinicOne.StartWorkTime = clinicVM.StartWorkTime;
                clinicOne.StoptWorkTime = clinicVM.StoptWorkTime;
                clinicOne.CategoryId = clinicVM.CategoryId;

                await unitOfWork.GetRepository<Clinic>().UpdateAsync(clinicOne);
                await unitOfWork.SaveChangeAsync();
            }
        }
    }
}
