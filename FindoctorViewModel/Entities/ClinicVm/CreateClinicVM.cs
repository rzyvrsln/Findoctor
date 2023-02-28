using System.ComponentModel.DataAnnotations;

namespace FindoctorViewModel.Entities.ClinicVm
{
    public class CreateClinicVM
    {
        [Required(ErrorMessage = "Ad boş olmamalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad boş olmamalıdır.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Ünvan boş olmamalıdır.")]
        public string Location { get; set; }
        [DataType(DataType.Time), Required(ErrorMessage = "Saat boş olmamalıdır.")]
        public DateTime StartWorkTime { get; set; }
        [DataType(DataType.Time), Required(ErrorMessage = "Saat boş olmamalıdır.")]
        public DateTime StoptWorkTime { get; set; }
        [Required(ErrorMessage = "Kateqoriya boş olmamalıdır.")]
        public int CategoryId { get; set; }
    }
}
