using FindoctorCore.Entities;

namespace FindoctorEntity.Entities
{
    public class Category:EntityBase
    {
        public string Name { get; set; }
        public ICollection<Specialty> Specialties { get; set; }
    }
}
