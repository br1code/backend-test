using EventsAPI.Models.DTOS;

namespace EventsAPI.Services.Contracts
{
    public interface IEventsService
    {
        Task<EventDetailsResult> GetEvent(int id);

        Task<IEnumerable<EventDateResult>> GetEventDates(bool featured);

        Task<int> CreateEvent(CreateEvent createEvent);
    }
}
