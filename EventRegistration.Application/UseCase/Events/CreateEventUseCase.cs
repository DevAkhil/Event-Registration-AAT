using AutoMapper;
using EventRegistration.Application.DTOs.Events;
using EventRegistration.Domain.Entities;
using EventRegistration.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Application.UseCase.Events
{
    public class CreateEventUseCase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mappper;
        public CreateEventUseCase(IEventRepository eventRepository, IMapper mappper)
        {
            _eventRepository = eventRepository;
            _mappper = mappper;
        }

        public async Task<GetEventDTO> Execute(CreateUpdateEventDTO input)
        {
            Domain.Entities.Events createdEvent = await _eventRepository.CreateAsync(_mappper.Map<Domain.Entities.Events>(input));
            return _mappper.Map<GetEventDTO>(createdEvent);

        }



    }
}
