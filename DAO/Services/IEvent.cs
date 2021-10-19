using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Services
{
    public interface IEvent
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        ValueTask<Event> GetEventByIdAsync(int id);
        Task<Event> RemoveEvent(Event DelEvent);
        Task<Event> CreateEventAsync(Event CreateEvent);
        Task UpdateEventAsync(Event currentEvent, Event newEvent);

    }
}
