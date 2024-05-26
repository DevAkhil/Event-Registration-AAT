using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Domain.Entities
{
    public class Events
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EventId { get; set; } = Guid.NewGuid();

        [StringLength(100)]
        [Required]
        public string EventName { get; set; } = string.Empty;

        [StringLength(1000)]
        [Required]
        public string EventDescription { get; set; } = string.Empty;
        public string? EventImgUrl { get; set; }
        [Required]
        public int MaxSeats { get; set; }
        public virtual ICollection<EventRegister> EventRegistrations { get; set; } = new List<EventRegister>();


    }
}
