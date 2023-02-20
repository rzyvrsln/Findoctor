using System.ComponentModel.DataAnnotations;

namespace FindoctorViewModel.Entities.Account
{
    public class CraeteDoctorRegisterVM
    {
        [Required(ErrorMessage = "Ad boş olmamalıdır")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad boş olmamalıdır")]
        public string Surname { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Şifrə boş olmamalıdır.")]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password)), Required(ErrorMessage = "Şifrə boş olmamalıdır.")]
        public string ComfirmPassword { get; set; }
        [Required(ErrorMessage = "Istifadəçi adı boş olmamalıdır")]
        public string UserName { get; set; }
    }
}
