namespace EventsAPI.Models.DTOS
{
    public class NewEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public bool Featured { get; set; }
        public IEnumerable<NewEventDate> EventDates { get; set; }

        public NewEvent()
        {
            EventDates = new List<NewEventDate>();
        }
    }
}
