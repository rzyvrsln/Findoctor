using FindoctorCore.Entities;
using FindoctorEntity.Entities.ManyToMany;

namespace FindoctorEntity.Entities
{
    public class Patient:EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string İmageUrl { get; set; }

        public ICollection<DoctorPatient> DoctorPatients { get; set; }
    }
}
