using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Domain.Repositories
{
    public interface IEventRepository
    {
        Task<List<Entities.Events>> GetAllAsync();
        Task<List<Entities.Events>> GetAllAvailableAsync();
        Task<Entities.Events?> GetByEventId(Guid eventId);
        Task<Entities.Events> CreateAsync(Entities.Events events);
        Task<Entities.Events> UpdateAsync(Entities.Events events);
        void DeleteAsync(Entities.Events events);
    }
}
