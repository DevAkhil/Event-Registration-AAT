using AutoMapper;
using EventRegistration.Application.DTOs.EventRegistration;
using EventRegistration.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Application.UseCase.EventRegistration
{
    public class CreateEventRegistrationUseCase
    {
        private readonly IEventReigstrationRepository _eventReigstrationRepository;
        private readonly IMapper _mappper;

        public CreateEventRegistrationUseCase(IEventReigstrationRepository eventReigstrationRepository, IMapper mappper)
        {
            _eventReigstrationRepository = eventReigstrationRepository;
            _mappper = mappper;
        }

        public async Task<OutputEventRegistrationDTO> Execute(CreateEventRegistrationDTO input)
        {
            OutputEventRegistrationDTO output = new OutputEventRegistrationDTO();
            int remainingSeats = await _eventReigstrationRepository.GetRemainingSeats(input.EventId);
            Domain.Entities.EventRegister? currentUserRegistration = await _eventReigstrationRepository.GetByEventAndEmail(input.EventId, input.Email);

            if (remainingSeats <= 0)
            {
                output.IsRegisterd = false;
                output.UserFriendlyMessage = "No remaining seats for this event";
                return output;
            }
            if(currentUserRegistration != null)
            {
                output.IsRegisterd = true;
                output.UserFriendlyMessage = $"{currentUserRegistration.Email} is already registerd for this event.";
                return output;
            }

            Domain.Entities.EventRegister newRegister =  await _eventReigstrationRepository.CreateAsync(_mappper.Map<Domain.Entities.EventRegister>(input));
            output.IsRegisterd = true;
            output.UserFriendlyMessage = $"Registration successful. Your Reference is {newRegister.EventRegisterReference}.";
            return output;


        }


    }
}
