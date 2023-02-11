using FindoctorEntity.Entities;
using FluentValidation;

namespace FindoctorService.Validations
{
    public class CategoryValidation:AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(14).WithName("Kateqoriya");
            RuleFor(x => x.ImageUrl).NotEmpty().WithName("Şəkil");
        }
    }
}
