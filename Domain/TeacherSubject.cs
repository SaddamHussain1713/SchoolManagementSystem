namespace SchoolManagementSystem.Domain
{
    public class TeacherSubject
    {
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        // Navigation Properties

        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
    }
}
