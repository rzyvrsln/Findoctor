using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindoctorViewModel.Entities.Account
{
    public class CreateDoctorLoginVM
    {
        [Required(ErrorMessage = "Email boş olmamalıdır.")]
        public string Email { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Şifrə boş olmamalıdır.")]
        public string Password { get; set; }
        public bool IsParsistance { get; set; }
    }
}
