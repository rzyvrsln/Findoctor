using System.ComponentModel.DataAnnotations;

namespace FindoctorViewModel.Entities.Account
{
    public class CreateUserLoginVM
	{
        [Required(ErrorMessage ="İstifadəçi adı boş olmamalıdır.")]
        public string UserName { get; set; }
        [DataType(DataType.Password),Required(ErrorMessage = "Şifrə boş olmamalıdır.")]
        public string Password { get; set; }
        public bool IsParsistance { get; set; }
    }
}
