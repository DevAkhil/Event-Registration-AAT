using EventRegistration.Application.DTOs.Events;


namespace EventRegisterstration.Service.Interface
{
    public interface IEventService
    {
        Task<List<ViewEventDTO>> GetAvailableEventsAsync();
        Task<List<GetEventDTO>> GetAllEventsAsync();
        Task<GetEventDTO> GetEventByIdAsync(Guid eventId);
        Task<GetEventDTO> CreateEventAsync(CreateUpdateEventDTO input);
        Task<GetEventDTO> UpdateEventAsync(Guid eventId, CreateUpdateEventDTO input);
        Task<bool> DeleteEventAsync(Guid eventId);
    }
}
