using Events.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.Service
{
    public interface IEventsService
    {
        public Task<List<Event>> getFullEvents();
        public Event getFullEventById(string fullEventId);
        public Event postFullEvent(Event fullEventObj);
        public Event updateFullEvent(string fullEventId, Event fullEvent);
        public Event patchFullEvent(string fullEventId, Event fullEvent);
        public void deleteFullEvent(string fullEvent);
    }
}
