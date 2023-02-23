using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FindoctorViewModel.Entities.DoctorVM
{
    public class UpdateDoctorVM
    {
        [Required(ErrorMessage = "Ad boş qala bilməz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad boş qala bilməz.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Telefon nömrəsi boş qala bilməz.")]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress), Required(ErrorMessage = "Email boş qala bilməz.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Boş qala bilməz.")]
        public string About { get; set; }
        [Required(ErrorMessage = "Cins boş qala bilməz.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Şəkil boş qala bilməz.")]
        public IFormFile Image { get; set; }
        [DataType(DataType.Time, ErrorMessage = "Saat daxil edin.")]
        public DateTime StartWorkTime { get; set; }
        [DataType(DataType.Time, ErrorMessage = "Saat daxil edin.")]
        public DateTime StopWorkTime { get; set; }
        [Required(ErrorMessage = "Qiymət daxil edin.")]
        public float Paymant { get; set; }

        [Required(ErrorMessage = "Klinika boş qala bilməz.")]
        public int ClinicId { get; set; }
        [Required(ErrorMessage = "Kateqoriya boş qala bilməz.")]
        public int CategoryId { get; set; }
    }
}
