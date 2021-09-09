using Events.DAO;
using Events.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.Service
{
    public class EventsService
    {
        private EventsDAO events { get; }

        public EventsService()
        {
        }
        public async Task<List<Event>> getEvents()
        {
            var events = await DAOFacade.Instance.EventsDao.getEvents();
            return events;
        }
    }
}
