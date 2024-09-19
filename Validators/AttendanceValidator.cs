using FluentValidation;
using SchoolManagementSystem.Domain;
namespace SchoolManagementSystem.Validators
{
    public class AttendanceValidator : AbstractValidator<Attendance>
    {
        public AttendanceValidator()
        {
            RuleFor(attendance => attendance.StudentId)
                .GreaterThan(0).WithMessage("Student ID must be a positive number.");

            RuleFor(attendance => attendance.ClassId)
                .GreaterThan(0).WithMessage("Class ID must be a positive number.");

            RuleFor(attendance => attendance.Date)
                .NotEmpty().WithMessage("Date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Date must not be in the future.");

            RuleFor(attendance => attendance.IsPresent)
                .NotNull().WithMessage("Attendance status must be provided.");
        }
    }

}
