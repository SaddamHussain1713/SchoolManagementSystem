using FluentValidation;
using SchoolManagementSystem.Domain;
namespace SchoolManagementSystem.Validators
{
    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator()
        {
            RuleFor(evt => evt.Name)
                .NotEmpty().WithMessage("Event Name is required.")
                .Length(2, 100).WithMessage("Event Name must be between 2 and 100 characters.");

            RuleFor(evt => evt.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(10, 500).WithMessage("Description must be between 10 and 500 characters.");

            RuleFor(evt => evt.EventDate)
                .NotEmpty().WithMessage("Event Date is required.")
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Event Date must not be in the past.");

            RuleFor(evt => evt.Location)
                .NotEmpty().WithMessage("Location is required.")
                .Length(2, 200).WithMessage("Location must be between 2 and 200 characters.");

            RuleFor(evt => evt.TeacherId)
                .GreaterThan(0).WithMessage("Teacher ID must be a positive number.");
        }
    }



}
