namespace EventsAPI.Models
{
    public class EventDate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public Event Event { get; set; }
    }
}
