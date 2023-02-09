using FindoctorCore.Entities;

namespace FindoctorEntity.Entities
{
    public class Specialty:EntityBase
    {
        public string Name { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
