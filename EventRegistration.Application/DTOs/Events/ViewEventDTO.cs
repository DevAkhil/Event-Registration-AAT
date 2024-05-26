

namespace EventRegistration.Application.DTOs.Events
{
    public class ViewEventDTO
    {
        public Guid EventId { get; set; }

        public string EventName { get; set; } = string.Empty;

        public string EventDescription { get; set; } = string.Empty;
        public string? EventImgUrl { get; set; }
        public int AssignedSeats { get; set; }
        public int MaxSeats { get; set; }
        public bool IsRegisterd { get; set; }

    }
}
