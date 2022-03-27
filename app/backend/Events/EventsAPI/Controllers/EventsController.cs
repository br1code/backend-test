using EventsAPI.Models.DTOS;
using EventsAPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers
{
    // TODO: implement MediatR
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsService _eventsService;

        public EventsController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetailsResult>> GetEvent([FromRoute]int id)
        {
            // TODO: add try catch
            var result = await _eventsService.GetEvent(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // TODO: add simple pagination
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDateResult>>> GetEvents([FromQuery] bool featured)
        {
            // TODO: add try catch
            var result = await _eventsService.GetEventDates(featured);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateEvent([FromBody] CreateEvent createEvent)
        {
            // TODO: add try catch
            var result = await _eventsService.CreateEvent(createEvent);

            return Ok(result);
        }
    }
}
