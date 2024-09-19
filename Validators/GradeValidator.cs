using FluentValidation;
using SchoolManagementSystem.Domain;
namespace SchoolManagementSystem.Validators
{
    public class GradeValidator : AbstractValidator<Grade>
    {
        public GradeValidator()
        {
            RuleFor(grade => grade.StudentId)
                .GreaterThan(0).WithMessage("Student ID must be a positive number.");

            RuleFor(grade => grade.SubjectId)
                .GreaterThan(0).WithMessage("Subject ID must be a positive number.");

            RuleFor(grade => grade.GradeValue)
                .NotEmpty().WithMessage("Grade value is required.")
                .Matches("^[A-F]$").WithMessage("Grade must be a valid grade (A, B, C, D, E, F).");
        }
    }


}
