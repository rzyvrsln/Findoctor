namespace FindoctorEntity.Entities.ManyToMany
{
    public class DoctorPatient
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
