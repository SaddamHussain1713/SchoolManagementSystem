namespace SchoolManagementSystem.Domain
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        // Navigation Properties
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Class> Classes { get; set; }

        // Constructor
        public Subject()
        {
            Teachers = new List<Teacher>();
            Classes = new List<Class>();
        }
    }
}
