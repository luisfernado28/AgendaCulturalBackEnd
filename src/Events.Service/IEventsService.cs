using Events.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.Service
{
    public interface IEventsService
    {
        public Task<List<Event>> getEvents();
        public Task<Event> getEventById(string eventId);
        public Task<Event> postEvent(Event eventObj);
        public Task<Event> updateEvent(string eventId,Event eventObj);
        public Task<Event> patchEvent(string eventId,Event eventObj);
        public Task deleteEvent(string eventId);
    }
}
