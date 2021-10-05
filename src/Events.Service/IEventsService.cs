using Events.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.Service
{
    public interface IEventsService
    {
        public Task<List<Event>> getEvents();
    }
}
