using FluentValidation;
using SchoolManagementSystem.Domain.SchoolManagementSystem.Domain;

namespace SchoolManagementSystem.Validators
{
    public class StudentFeeValidator : AbstractValidator<StudentFee>
    {
        public StudentFeeValidator()
        {
            RuleFor(studentFee => studentFee.StudentId)
                .GreaterThan(0).WithMessage("Student ID is required and must be a positive number.");

            RuleFor(studentFee => studentFee.FeeId)
                .GreaterThan(0).WithMessage("Fee ID is required and must be a positive number.");

            RuleFor(studentFee => studentFee.AmountPaid)
                .GreaterThanOrEqualTo(0).WithMessage("Amount Paid must be greater than or equal to zero.");

            RuleFor(studentFee => studentFee.RemainingBalance)
                .GreaterThanOrEqualTo(0).WithMessage("Remaining Balance must be greater than or equal to zero.");

            RuleFor(studentFee => studentFee.IsPaid)
                .Must((studentFee,isPaid) => isPaid == true || studentFee.RemainingBalance > 0)
                .WithMessage("If the fee is fully paid, the remaining balance must be zero.");
        }
    }


}
