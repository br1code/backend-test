namespace EventsAPI.Models.DTOS
{
    // TODO: please install MediatR
    public class CreateEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public bool Featured { get; set; }
        public IEnumerable<CreateEventDate> EventDates { get; set; }
    }
}
