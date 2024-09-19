using FluentValidation;
using SchoolManagementSystem.Domain;
namespace SchoolManagementSystem.Validators
{
    public class ClassValidator : AbstractValidator<Class>
    {
        public ClassValidator()
        {
            RuleFor(cls => cls.ClassName)
                .NotEmpty().WithMessage("Class Name is required.")
                .Length(2, 50).WithMessage("Class Name must be between 2 and 50 characters.");
        }
    }


}
