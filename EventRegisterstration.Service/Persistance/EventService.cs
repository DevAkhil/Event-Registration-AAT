using EventRegisterstration.Service.Interface;
using EventRegistration.Application.DTOs.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EventRegisterstration.Service.Persistance
{
    public class EventService:IEventService
    {
        private readonly HttpClient _httpClient;

        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ViewEventDTO>> GetAvailableEventsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ViewEventDTO>>("api/events/GetAvailable");
        }

        public async Task<List<GetEventDTO>> GetAllEventsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<GetEventDTO>>("api/events/GetAll");
        }

        public async Task<GetEventDTO> GetEventByIdAsync(Guid eventId)
        {
            return await _httpClient.GetFromJsonAsync<GetEventDTO>($"api/events/{eventId}");
        }

        public async Task<GetEventDTO> CreateEventAsync(CreateUpdateEventDTO input)
        {
            var response = await _httpClient.PostAsJsonAsync("api/events", input);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<GetEventDTO>();
            }
            return null;
        }

        public async Task<GetEventDTO> UpdateEventAsync(Guid eventId, CreateUpdateEventDTO input)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/events/{eventId}", input);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<GetEventDTO>();
            }
            return null;
        }

        public async Task<bool> DeleteEventAsync(Guid eventId)
        {
            var response = await _httpClient.DeleteAsync($"api/events/{eventId}");
            return response.IsSuccessStatusCode;
        }
    }
}
