namespace SchoolManagementSystem.Domain
{

    namespace SchoolManagementSystem.Domain
    {
        public class StudentFee
        {
            public int StudentFeeId { get; set; }
            public int StudentId { get; set; }
            public int FeeId { get; set; }
            public bool IsPaid { get; set; }
            public DateTime? PaymentDate { get; set; } // Nullable, only set when the fee is fully paid
            public decimal AmountPaid { get; set; } // Total amount paid by the student
            public decimal RemainingBalance { get; set; } // Remaining balance to be paid

            // Navigation Properties
            public Student Student { get; set; }
            public Fee Fee { get; set; }

            // Method to Update Payment
            public void AddPayment(decimal paymentAmount)
            {
                AmountPaid += paymentAmount;
                RemainingBalance -= paymentAmount;

                // Ensure remaining balance is not negative
                if (RemainingBalance <= 0)
                {
                    RemainingBalance = 0;
                    IsPaid = true;
                    PaymentDate = DateTime.Now;
                }
            }
        }
    }


}
