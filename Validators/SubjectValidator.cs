using FluentValidation;
using SchoolManagementSystem.Domain;
namespace SchoolManagementSystem.Validators
{
    public class SubjectValidator : AbstractValidator<Subject>
    {
        public SubjectValidator()
        {
            RuleFor(subject => subject.SubjectName)
                .NotEmpty().WithMessage("Subject Name is required.")
                .Length(2, 100).WithMessage("Subject Name must be between 2 and 100 characters.");
        }
    }

}
