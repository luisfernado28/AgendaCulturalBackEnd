using Events.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.DAO
{
    public interface IEventsDAO
    {
        public Task<List<Event>> getFullEvents();
        public Event getFullEventsById(string fullEventId);
        public Event postFullEvent(Event fullEvent);
        public Event updateFullEvent(string eventId, Event fullEvent);
        public Event patchFullEvent(string eventId, Event fullEvent);
        public void deleteFullEvent(string fullEventId);
    }
}
