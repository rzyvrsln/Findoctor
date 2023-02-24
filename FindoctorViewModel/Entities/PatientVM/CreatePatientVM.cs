using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindoctorViewModel.Entities.PatientVM
{
    public class CreatePatientVM
    {
        [Required(ErrorMessage = "Ad boş olmamalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad boş olmamalıdır.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email boş olmamalıdır.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Cins boş olmamalıdır.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Şəkil boş olmamalıdır.")]
        public IFormFile? Image { get; set; }
        [DataType(DataType.Time),Required(ErrorMessage = "Saat boş olmamalıdır.")]
        public DateTime Time { get; set; }
        [Required(ErrorMessage = "Məbləğ boş olmamalıdır.")]
        public float Paymant { get; set; }
        [Phone,Required(ErrorMessage = "Nömrə boş olmamalıdır.")]
        public string Phone { get; set; }
    }
}
