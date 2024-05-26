using EventRegisterstration.Service.Interface;
using EventRegistration.Application.DTOs.EventRegistration;
using EventRegistration.Application.DTOs.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EventRegisterstration.Service.Persistance
{
    public class EventRegistrationService:IEventRegistrationService
    {
        private readonly HttpClient _httpClient;

        public EventRegistrationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OutputEventRegistrationDTO> CreateRegistration(CreateEventRegistrationDTO input)
        {
            var response = await _httpClient.PostAsJsonAsync("api/eventregistration", input);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<OutputEventRegistrationDTO>();
            }
            return null;

        }

      


    }
}
