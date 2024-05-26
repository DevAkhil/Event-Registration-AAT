
namespace EventRegistration.Application.DTOs.Events
{
    public class GetEventDTO:CreateUpdateEventDTO
    {
        public Guid EventId { get; set; }
    }
}
