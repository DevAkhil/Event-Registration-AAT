using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Application.DTOs.EventRegistration
{
    public class OutputEventRegistrationDTO
    {
        public bool IsRegisterd { get; set; }
        public string UserFriendlyMessage { get; set; } = string.Empty;
    }
}
