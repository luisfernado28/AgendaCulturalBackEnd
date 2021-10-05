using Events.DAO;
using Events.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.Service
{
    public class EventsService : IEventsService
    {
        private IEventsDAO _eventsDao;


        public EventsService(IEventsDAO eventsDAO)
        {
            _eventsDao = eventsDAO;
        }
        public async Task<List<Event>> getEvents()
        {
            var events = await _eventsDao.getEvents();
            return events;
        }
    }
}
