namespace SchoolManagementSystem.Domain
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string GradeValue { get; set; }

        // Navigation Properties
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
