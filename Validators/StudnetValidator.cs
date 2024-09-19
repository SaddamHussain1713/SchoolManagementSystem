using FluentValidation;
using SchoolManagementSystem.Domain;

namespace SchoolManagementSystem.Validators
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(student => student.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters.");

            RuleFor(student => student.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.");

            RuleFor(student => student.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(student => student.DateOfBirth)
                .NotEmpty().WithMessage("Date of Birth is required.")
                .LessThan(DateTime.Now).WithMessage("Date of Birth must be in the past.");

            RuleFor(student => student.ClassId)
                .GreaterThan(0).WithMessage("Class ID must be a positive number.");
        }
    }

}
