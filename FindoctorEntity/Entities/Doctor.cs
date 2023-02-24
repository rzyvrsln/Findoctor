using FindoctorCore.Entities;

namespace FindoctorEntity.Entities
{
    public class Doctor:EntityBase
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string About { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartWorkTime { get; set; }
        public DateTime StopWorkTime { get; set; }
        public float Paymant { get; set; }
        public bool IsActive { get; set; } = true;

        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<DoctorPatient>? DoctorPatients { get; set; }
    }
}
