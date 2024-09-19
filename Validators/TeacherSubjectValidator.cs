using FluentValidation;
using SchoolManagementSystem.Domain;
namespace SchoolManagementSystem.Validators
{
    public class TeacherSubjectValidator : AbstractValidator<TeacherSubject>
    {
        public TeacherSubjectValidator()
        {
            RuleFor(teacherSubject => teacherSubject.TeacherId)
                .GreaterThan(0).WithMessage("Teacher ID must be a positive number.");

            RuleFor(teacherSubject => teacherSubject.SubjectId)
                .GreaterThan(0).WithMessage("Subject ID must be a positive number.");
        }
    }


}
