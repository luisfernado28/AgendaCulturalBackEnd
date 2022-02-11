using Events.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.DAO
{
    public interface IFullEventsDAO
    {
        public Task<List<FullEvent>> getFullEvents();
        public Task<FullEvent> getFullEventsById(string fullEventId);
        //public Task<Event> postEvent(Event Event);
        //public Task<Event> updateEvent(string eventId, Event Event);
        //public Task<Event> patchEvent(string eventId, Event Event);
        //public Task deleteEvent(string eventId);
    }
}
