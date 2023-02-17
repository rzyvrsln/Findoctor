using Microsoft.AspNetCore.Http;

namespace FindoctorViewModel.Entities.DoctorVM
{
    public class UpdateDoctorVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public IFormFile Image { get; set; }
        public DateTime StartWorkTime { get; set; }
        public DateTime StopWorkTime { get; set; }

        public int ClinicId { get; set; }
        public int CategoryId { get; set; }
    }
}
