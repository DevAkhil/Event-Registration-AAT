using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Domain.Repositories
{
    public interface IEventReigstrationRepository
    {
        Task<Entities.EventRegister?> GetByEventAndEmail(Guid eventId, string email);
        Task<int> GetRemainingSeats(Guid eventId);
        Task<Entities.EventRegister> CreateAsync(Entities.EventRegister eventRegister);



    }
}
