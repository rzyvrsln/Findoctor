using FindoctorCore.Entities;
using FindoctorEntity.Entities.ManyToMany;

namespace FindoctorEntity.Entities
{
    public class Doctor:EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }

        public Guid ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public ICollection<DoctorPatient>? DoctorPatients { get; set; }
    }
}
