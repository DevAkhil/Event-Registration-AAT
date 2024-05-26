using EventRegistration.Domain.Entities;
using EventRegistration.Domain.Repositories;
using EventRegistration.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Infrastructure.Persistence
{
    public class EventRepository : IEventRepository
    {
        private readonly EventRegistrationContext _eventRegistrationContext;

        public EventRepository(EventRegistrationContext eventRegistrationContext)
        {
            _eventRegistrationContext = eventRegistrationContext;
        }

        public async Task<List<Events>> GetAllAsync()
        {
            return await _eventRegistrationContext.Events.ToListAsync();
        }
        public async Task<List<Events>> GetAllAvailableAsync()
        {
            var x = await _eventRegistrationContext.Events
                    .Include(x=>x.EventRegistrations)
                    //.Where(x => (x.MaxSeats > x.EventRegistrations.Count())) //optional
                    .ToListAsync();
            return x;
        }

        public async Task<Events?> GetByEventId(Guid eventId)
        {
            return await _eventRegistrationContext.Events.FindAsync(eventId); 
        }
        public async Task<Events> CreateAsync(Events events)
        {
            await _eventRegistrationContext.AddAsync(events);
            await _eventRegistrationContext.SaveChangesAsync();
            return events;
        }



        public async Task<Events> UpdateAsync(Events Events)
        {
            _eventRegistrationContext.Update(Events);
            await _eventRegistrationContext.SaveChangesAsync();
            return Events;
        }

        public async void DeleteAsync(Events Events)
        {
             _eventRegistrationContext.Events.Remove(Events);
            await _eventRegistrationContext.SaveChangesAsync();
        }
    }
}
