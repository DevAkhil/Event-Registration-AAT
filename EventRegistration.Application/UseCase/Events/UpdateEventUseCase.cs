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
    public class UpdateEventUseCase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mappper;
        public UpdateEventUseCase(IEventRepository eventRepository, IMapper mappper)
        {
            _eventRepository = eventRepository;
            _mappper = mappper;
        }

        public async Task<CreateUpdateEventDTO?> Execute(Guid eventId, CreateUpdateEventDTO input)
        {
            Domain.Entities.Events? oldEventsObj = await _eventRepository.GetByEventId(eventId);
            if (oldEventsObj is null)
            {
                return null;
            }
            Domain.Entities.Events updateEventsObj = _mappper.Map(input, oldEventsObj);
            updateEventsObj = await _eventRepository.UpdateAsync(updateEventsObj);
            return _mappper.Map<CreateUpdateEventDTO>(updateEventsObj);
        }



    }
}
