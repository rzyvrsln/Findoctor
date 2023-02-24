using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.PatientVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindoctorViewModel.Entities.DoctorPatientCombinedVM
{
    public class CombinedViewModel
    {
        public Doctor doctors { get; set; }
        public Patient patients { get;set; } 
        public CreatePatientVM createPatientVM { get; set; }
        public UpdatePatientVM updatePatientVM { get; set; }
    }
}
