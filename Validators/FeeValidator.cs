using FluentValidation;
using SchoolManagementSystem.Domain.SchoolManagementSystem.Domain;

namespace SchoolManagementSystem.Validators
{
    public class FeeValidator : AbstractValidator<Fee>
    {
        public FeeValidator()
        {
            RuleFor(fee => fee.FeeType)
                .NotEmpty().WithMessage("Fee Type is required.")
                .Length(2, 100).WithMessage("Fee Type must be between 2 and 100 characters.");

            RuleFor(fee => fee.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than zero.");

            RuleFor(fee => fee.DueDate)
                .NotEmpty().WithMessage("Due Date is required.")
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Due Date must not be in the past.");

            RuleFor(fee => fee.ClassId)
                .GreaterThan(0).When(fee => fee.ClassId.HasValue).WithMessage("Class ID must be a positive number if provided.");
        }
    }
}
