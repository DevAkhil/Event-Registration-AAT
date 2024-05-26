using EventRegistration.Domain.Entities;
using EventRegistration.Domain.Repositories;
using EventRegistration.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Infrastructure.Persistence
{
    public class EventRegistrationRepository:IEventReigstrationRepository
    {
        private readonly EventRegistrationContext _eventRegistrationContext;

        public EventRegistrationRepository(EventRegistrationContext eventRegistrationContext)
        {
            _eventRegistrationContext = eventRegistrationContext;
        }

        public async Task<EventRegister> CreateAsync(EventRegister eventRegister)
        {
            await _eventRegistrationContext.AddAsync(eventRegister);
            await _eventRegistrationContext.SaveChangesAsync();
            var x= _eventRegistrationContext.EventRegister.ToList();
            return eventRegister;
        }

        public async Task<EventRegister?> GetByEventAndEmail(Guid eventId, string email)
        {
            return await _eventRegistrationContext.EventRegister.FirstOrDefaultAsync(x => x.EventId == eventId && x.Email.Trim().ToLower() == email.Trim().ToLower());
        }

        public async Task<int> GetRemainingSeats(Guid eventId)
        {
            int seated = _eventRegistrationContext.EventRegister.Where(x => x.EventId == eventId).Count();
            Domain.Entities.Events? selectedEvent = await _eventRegistrationContext.Events.FindAsync(eventId);
            return selectedEvent!.MaxSeats - seated;
        }
    }
}
