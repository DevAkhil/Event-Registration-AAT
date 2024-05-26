using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Domain.Entities
{
    public class EventRegister
    {
        public EventRegister()
        {
            EventRegisterReference = GenerateEventRegisterReference();
        }

        [Key]
        [StringLength(50)]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EventRegisterReference { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public Guid EventId { get; set; }
        [ForeignKey("EventId")]
        public Events Events { get; set; }

        public string GenerateEventRegisterReference()
        {
            return $"AAT-{DateTime.Now:dd-MM-yyyy}-{GenerateRandomDigits()}";
        }

        private string GenerateRandomDigits()
        {
            Random random = new Random();
            return random.Next(1000000, 9999999).ToString();
        }
    }
}
