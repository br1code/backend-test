using EventsAPI.Models.DTOS;
using EventsAPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers
{
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
        public async Task<ActionResult<EventDetailsResult>> GetEvent([FromRoute] int id)
        {
            // TODO: add try catch
            var result = await _eventsService.GetEvent(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // TODO: consider creating a class for query params
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDateResult>>> GetEvents([FromQuery] bool featured,
            [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            // TODO: add try catch
            var result = await _eventsService.GetEventDates(featured, pageNumber, pageSize);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateEvent([FromForm] NewEvent createEvent)
        {
            // TODO: add try catch
            try
            {
                var result = await _eventsService.CreateEvent(createEvent);

                return Ok(result);
            }
            catch (Exception ex)
            {
                // TODO: ???
                return BadRequest(ex);
            }

        }
    }
}
