using FindoctorData.UnitOfWorks;
using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.ClinicVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<ICollection<Clinic>> GetAllClinicAsync()
        {
            await unitOfWork.GetRepository<Clinic>().AnyAsync(x=>x.Category);
            return await unitOfWork.GetRepository<Clinic>().GetAllAsync();
        }
    }
}
