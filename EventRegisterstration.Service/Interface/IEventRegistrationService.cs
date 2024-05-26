using EventRegistration.Application.DTOs.EventRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegisterstration.Service.Interface
{
    public interface IEventRegistrationService
    {
        Task<OutputEventRegistrationDTO> CreateRegistration(CreateEventRegistrationDTO input);
    }
}
