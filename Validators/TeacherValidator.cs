using FluentValidation;
using SchoolManagementSystem.Domain;

namespace SchoolManagementSystem.Validators
{
    public class TeacherValidator : AbstractValidator<Teacher>
    {
        public TeacherValidator()
        {
            RuleFor(teacher => teacher.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters.");

            RuleFor(teacher => teacher.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.");

            RuleFor(teacher => teacher.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.");
        }
    }

}
