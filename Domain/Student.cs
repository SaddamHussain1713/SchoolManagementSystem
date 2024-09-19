using SchoolManagementSystem.Domain.SchoolManagementSystem.Domain;

namespace SchoolManagementSystem.Domain
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int? ClassId { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Navigation Properties
        public Class Class { get; set; }
        public ICollection<Attendance> AttendanceRecords { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<StudentFee> StudentFees { get; set; } // Navigation to StudentFee

        // Constructor
        public Student()
        {
            AttendanceRecords = new List<Attendance>();
            Grades = new List<Grade>();
            StudentFees = new List<StudentFee>();
        }
    }
}
