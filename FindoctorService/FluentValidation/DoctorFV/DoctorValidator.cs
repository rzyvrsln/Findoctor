using FindoctorEntity.Entities;
using FluentValidation;

namespace FindoctorService.FluentValidation.DoctorFV
{
    public class DoctorValidator:AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20).WithName("Ad");
            RuleFor(x => x.Surname).NotEmpty().NotNull().MinimumLength(3).MaximumLength(22).WithName("Soyad");
            RuleFor(x => x.Phone).NotEmpty().NotNull().MinimumLength(30).MaximumLength(30).WithName("Telefon nömrəsi");
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress().WithName("Email");
            RuleFor(x => x.Gender).NotEmpty().NotNull().WithName("Cins");
            RuleFor(x => x.ImageUrl).NotEmpty().NotNull().Must(x => x.Equals("image/")).WithName("Şəkil");
            RuleFor(x => x.StartWorkTime).NotEmpty().NotNull().WithName("Saat");
            RuleFor(x => x.StopWorkTime).NotEmpty().NotNull().WithName("Saat");
            RuleFor(x => x.CategoryId).NotEmpty().NotNull().WithName("Kateqoriya");
            RuleFor(x => x.ClinicId).NotEmpty().NotNull().WithName("Klinika");
        }
    }
}
