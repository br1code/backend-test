namespace EventsAPI.Models.DTOS
{
    public class EventDateResult
    {
        public int EventId { get; set; }
        public int EventDateId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool Featured { get; set; }
        public DateTime Date { get; set; }
    }
}
