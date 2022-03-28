using EventsAPI.Data;
using EventsAPI.Models;
using EventsAPI.Models.DTOS;
using EventsAPI.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Services.Implementations
{
    public class EventsService : IEventsService
    {
        private const int MIN_PAGE_NUMBER = 1;
        private const int MIN_PAGE_SIZE = 5;
        private readonly EventsDbContext _dbContext;

        public EventsService(EventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateEvent(NewEvent createEvent)
        {
            // TODO: add validation
            var newEvent = new Event
            {
                Title = createEvent.Title,
                Description = createEvent.Description,
                Location = createEvent.Location,
                Image = createEvent.Image,
                Featured = createEvent.Featured,
                EventDates = createEvent.EventDates.Select(e => new EventDate
                {
                    Date = e.Date,
                    Price = e.Price
                }).ToList()
            };

            await _dbContext.Events.AddAsync(newEvent);
            await _dbContext.SaveChangesAsync();

            return newEvent.Id; // TODO: investigate whether we should/can return the id or not
        }

        public async Task<EventDetailsResult> GetEvent(int id)
        {
            var result = await _dbContext.Events.
                Include(e => e.EventDates)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (result == null)
            {
                return null;
            }

            // TODO: use automapper?
            return new EventDetailsResult
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                Location = result.Location,
                Image = result.Image,
                Featured = result.Featured,
                EventDates = result.EventDates.Select(e => new EventDetailsDateResult
                {
                    Id = e.Id,
                    Date = e.Date,
                    Price = e.Price
                }).ToList()
            };
        }

        public async Task<IEnumerable<EventDateResult>> GetEventDates(bool featured, int pageNumber, int pageSize)
        {
            pageNumber = pageNumber < MIN_PAGE_NUMBER ? MIN_PAGE_NUMBER : pageNumber;
            pageSize = pageSize < MIN_PAGE_SIZE ? MIN_PAGE_SIZE : pageSize;

            return await _dbContext.EventDates
                .Where(e => e.Event.Featured == featured)
                .OrderBy(e => e.Date)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(e => new EventDateResult
                {
                    EventId = e.Event.Id,
                    EventDateId = e.Id,
                    Title = e.Event.Title,
                    Description = e.Event.Description,
                    Image = e.Event.Image,
                    Featured = e.Event.Featured,
                    Date = e.Date
                })
            .ToListAsync();
        }
    }
}
