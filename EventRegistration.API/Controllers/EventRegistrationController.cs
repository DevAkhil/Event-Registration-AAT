using EventRegistration.Application.DTOs.EventRegistration;
using EventRegistration.Application.UseCase.EventRegistration;
using Microsoft.AspNetCore.Mvc;


namespace EventRegistration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRegistrationController : ControllerBase
    {
        private CreateEventRegistrationUseCase CreateEventRegistrationUseCase { get; set; }

        public EventRegistrationController(CreateEventRegistrationUseCase createEventRegistrationUseCase)
        {
            CreateEventRegistrationUseCase = createEventRegistrationUseCase;
        }

        [HttpPost]
        public async Task<ActionResult> CreateRegistration([FromBody] CreateEventRegistrationDTO input)
        {
            return Ok(await CreateEventRegistrationUseCase.Execute(input));
        }


    }
}
