using FindoctorCore.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindoctorEntity.Entities
{
    public class Clinic:EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartWorkTime { get; set; }
        public DateTime StoptWorkTime { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Doctor> Doctors { get; set; }

    }
}
