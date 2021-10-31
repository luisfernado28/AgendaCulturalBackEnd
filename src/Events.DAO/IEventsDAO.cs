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
        public Task<List<Event>> getEvents();
        public Task<Event> postEvent(Event Event);
        public Task<Event> updateEvent(string eventId, Event Event);
        public Task<Event> patchEvent(string eventId, Event Event);
        public Task deleteEvent(string eventId);
    }
}
