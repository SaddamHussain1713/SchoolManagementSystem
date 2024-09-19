namespace SchoolManagementSystem.Domain
{
    public class Timetable
    {
        public int TimetableId { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; } // Enum for days of the week

        // Navigation Properties
        public Class Class { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
    }
}
