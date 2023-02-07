using FindoctorCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindoctorEntity.Entities
{
    public class Doctor:EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
