namespace SchoolManagementSystem.Domain
{
    public class EventAttendee
    {
        public int EventId { get; set; }
        public int StudentId { get; set; }

        // Navigation Properties
        public Event Event { get; set; }
        public Student Student { get; set; }
    }


}