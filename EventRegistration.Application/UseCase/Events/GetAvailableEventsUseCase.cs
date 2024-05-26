using AutoMapper;
using EventRegistration.Application.DTOs.Events;
using EventRegistration.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Application.UseCase.Events
{
    public class GetAvailableEventsUseCase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mappper;
        public GetAvailableEventsUseCase(IEventRepository eventRepository, IMapper mappper)
        {
            _eventRepository = eventRepository;
            _mappper = mappper;
        }


        public async Task<List<ViewEventDTO>> Execute()
        {
            return  _mappper.Map<List<ViewEventDTO>>(await _eventRepository.GetAllAvailableAsync());
        }

    }
}
