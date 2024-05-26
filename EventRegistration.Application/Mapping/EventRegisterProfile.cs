using AutoMapper;
using EventRegistration.Application.DTOs.EventRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Application.Mapping
{
    public class EventRegisterProfile:Profile
    {
        public EventRegisterProfile()
        {
            CreateMap<CreateEventRegistrationDTO, Domain.Entities.EventRegister>();
        }


    }
}
