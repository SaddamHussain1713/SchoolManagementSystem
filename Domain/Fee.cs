namespace SchoolManagementSystem.Domain
{

    namespace SchoolManagementSystem.Domain
    {
        public class Fee
        {
            public int FeeId { get; set; }
            public string FeeType { get; set; } // e.g., "Tuition", "Library", "Exam"
            public decimal Amount { get; set; }
            public DateTime DueDate { get; set; }
            public int? ClassId { get; set; } // Optional: Fees might be applicable to a specific class/grade

            // Navigation Properties
            public Class Class { get; set; } // Reference to the applicable class (if any)
            public ICollection<StudentFee> StudentFees { get; set; }

            // Constructor
            public Fee()
            {
                StudentFees = new List<StudentFee>();
            }

            // Calculated property to check total amount paid by all students for this fee
            public decimal TotalCollectedAmount => StudentFees.Sum(sf => sf.AmountPaid);
        }
    }


}
