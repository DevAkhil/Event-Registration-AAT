using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EventRegistration.Application.DTOs.Events
{
    public class CreateUpdateEventDTO
    {
        [Required]
        [DisplayName("Event Name")]
        [StringLength(50)]
        public string EventName { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string EventDescription { get; set; } = string.Empty;
        public string? EventImgUrl { get; set; }
        [Required]
        public int MaxSeats { get; set; }
    }
}
