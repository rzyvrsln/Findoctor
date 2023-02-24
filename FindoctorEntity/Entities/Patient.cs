using FindoctorCore.Entities;

namespace FindoctorEntity.Entities
{
    public class Patient:EntityBase
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? İmageUrl { get; set; }
        public DateTime Time { get; set; }
        public float Paymant { get; set; }
        public string? Phone { get; set; }

        public ICollection<DoctorPatient> DoctorPatients { get; set; }
    }
}
