using AutoMapper;
using EventRegistration.Application.DTOs.Events;
using EventRegistration.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Application.UseCase.Events
{
    public class DeleteEventsUseCase
    {
        private readonly IEventRepository _eventRepository;
        public DeleteEventsUseCase(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<bool> Execute(Guid eventId)
        {
            var existingEvents = await _eventRepository.GetByEventId(eventId);
            if(existingEvents == null)
            {
                return false; 
            }
            _eventRepository.DeleteAsync(existingEvents);
            return true;
        }


    }
}
