using FindoctorCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindoctorEntity.Entities
{
    public class Patient:EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
