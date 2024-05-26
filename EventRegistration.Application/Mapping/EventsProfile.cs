using AutoMapper;
using EventRegistration.Application.DTOs.Events;
using EventRegistration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Application.Mapping
{
    public class EventsProfile:Profile
    {
        public EventsProfile()
        {
            CreateMap<Events, ViewEventDTO>()
           .ForMember(dest => dest.AssignedSeats, opt => opt.MapFrom(src => src.EventRegistrations.Count));
            CreateMap<CreateUpdateEventDTO, Events>().ReverseMap();
            CreateMap<Events, GetEventDTO> ();
        }



    }
}
