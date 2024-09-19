using SchoolManagementSystem.Domain.SchoolManagementSystem.Domain;

namespace SchoolManagementSystem.Domain
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }

        // Navigation Properties
        public ICollection<Student> Students { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Fee> Fees { get; set; }

        // Constructor
        public Class()
        {
            Students = new List<Student>();
            Subjects = new List<Subject>();
            Fees = new List<Fee>();
        }
    }
}
