using FindoctorData.UnitOfWorks;
using FindoctorEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindoctorService.Services
{
    internal class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ICollection<Patient>> GetPatientsAsync()
        {
            return await _unitOfWork.GetRepository<Patient>().GetAllAsync();
        }
    }
}
