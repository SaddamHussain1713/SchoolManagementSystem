namespace SchoolManagementSystem.Domain
{
    public class Event
    {
        public int EventId { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }

        // Navigation Properties
        public ICollection<EventAttendee> Attendees { get; set; }

        // Constructor
        public Event()
        {
            Attendees = new List<EventAttendee>();
        }
    }

}
