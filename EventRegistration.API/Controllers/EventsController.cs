using EventRegistration.Application.DTOs.Events;
using EventRegistration.Application.UseCase.Events;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventRegistration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private GetAvailableEventsUseCase GetAvailableEventsUseCase { get; set; }
        private CreateEventUseCase CreateEventUseCase { get; set; }
        private UpdateEventUseCase UpdateEventUseCase { get; set; }
        private DeleteEventsUseCase DeleteEventUseCase { get; set; }
        private GetAllEventsUseCase GetAllEventsUseCase { get; set; }

        public EventsController(GetAvailableEventsUseCase getAvailableEventsUseCase, CreateEventUseCase createEventUseCase, UpdateEventUseCase updateEventUseCase, DeleteEventsUseCase deleteEventUseCase, GetAllEventsUseCase getAllEventsUseCase)
        {
            GetAvailableEventsUseCase = getAvailableEventsUseCase;
            CreateEventUseCase = createEventUseCase;
            UpdateEventUseCase = updateEventUseCase;
            DeleteEventUseCase = deleteEventUseCase;
            GetAllEventsUseCase = getAllEventsUseCase;
        }


        // GET: api/<EventsController>
        [HttpGet("GetAvailable")]
        public async Task<ActionResult> GetAvailable()
        {
            var events = await GetAvailableEventsUseCase.Execute();
            if(events == null){ 
                return NotFound();
            }
            return Ok(events);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var events = await GetAllEventsUseCase.Execute();
            if (events == null)
            {
                return NotFound();
            }
            return Ok(events);
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EventsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUpdateEventDTO input)
        {
           return Ok(await CreateEventUseCase.Execute(input));
        }

        // PUT api/<EventsController>/5
        [HttpPut("{eventid}")]
        public async Task<ActionResult> Put(Guid eventid, [FromBody] CreateUpdateEventDTO input)
        {
            CreateUpdateEventDTO? updateEvent = await UpdateEventUseCase.Execute(eventid, input);
            if(updateEvent == null)
            {
                return NotFound();
            }
            return Ok(updateEvent);
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{eventId}")]
        public async Task<ActionResult> Delete(Guid eventId)
        {
            bool exists = await DeleteEventUseCase.Execute(eventId);
            if (exists)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
