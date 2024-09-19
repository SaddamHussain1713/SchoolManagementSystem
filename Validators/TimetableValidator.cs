using FluentValidation;
using SchoolManagementSystem.Domain;
namespace SchoolManagementSystem.Validators
{
    public class TimetableValidator : AbstractValidator<Timetable>
    {
        public TimetableValidator()
        {
            RuleFor(timetable => timetable.ClassId)
                .GreaterThan(0).WithMessage("Class ID must be a positive number.");

            RuleFor(timetable => timetable.SubjectId)
                .GreaterThan(0).WithMessage("Subject ID must be a positive number.");

            RuleFor(timetable => timetable.TeacherId)
                .GreaterThan(0).WithMessage("Teacher ID must be a positive number.");

            RuleFor(timetable => timetable.StartTime)
                .NotEmpty().WithMessage("Start Time is required.")
                .LessThan(timetable => timetable.EndTime).WithMessage("Start Time must be before End Time.");

            RuleFor(timetable => timetable.EndTime)
                .NotEmpty().WithMessage("End Time is required.");

            RuleFor(timetable => timetable.DayOfWeek)
                .IsInEnum().WithMessage("Invalid Day of the Week.");
        }
    }

}
