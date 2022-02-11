using Events.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.Service
{
    public interface IFullEventsService
    {
        public Task<List<FullEvent>> getFullEvents();
        public Task<FullEvent> getFullEventById(string fullEventId);
        //public Task<Event> postEvent(Event eventObj);
        //public Task<Event> updateEvent(string eventId,Event eventObj);
        //public Task<Event> patchEvent(string eventId,Event eventObj);
        //public Task deleteEvent(string eventId);
    }
}
