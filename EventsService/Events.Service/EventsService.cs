using Events.DAO;
using Events.Domain;
using System;
using System.Collections.Generic;

namespace Events.Service
{
    public class EventsService
    {
        private EventsDAO events { get; }

        public EventsService()
        {
            this.events = new EventsDAO();
        }
        public List<Event> getEvents()
        {
            return events.getEvents();
        }
    }
}
