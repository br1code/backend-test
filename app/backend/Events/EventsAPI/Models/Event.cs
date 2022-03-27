namespace EventsAPI.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public bool Featured { get; set; }
        public ICollection<EventDate> EventDates { get; set; }
    }
}
