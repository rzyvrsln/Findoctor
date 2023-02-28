using FindoctorCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindoctorEntity.Entities
{
    public class Review:EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Accept { get; set; }
        public string ImageUrl { get; set; }
        public int DoctorId { get; set; }
        public Doctor doctor { get; set; }
    }
}
