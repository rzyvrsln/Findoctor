using FindoctorEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindoctorService.Services
{
    public interface IPatientService
    {
        Task<ICollection<Patient>> GetPatientsAsync();
    }
}
