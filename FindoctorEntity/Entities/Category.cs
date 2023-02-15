using FindoctorCore.Entities;

namespace FindoctorEntity.Entities
{
    public class Category:EntityBase
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Clinic> Clinics { get; set; }
    }
}

