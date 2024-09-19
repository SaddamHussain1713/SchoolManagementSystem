namespace SchoolManagementSystem.Domain
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // Navigation Properties
        public ICollection<Subject> Subjects { get; set; }

        // Constructor
        public Teacher()
        {
            Subjects = new List<Subject>();
        }
    }
}
