using FindoctorCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindoctorEntity.Entities
{
    public class Clinic:EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public ICollection<Doctor>? Doctors { get; set; }
    }
}
