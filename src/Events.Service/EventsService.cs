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

        public async Task deleteEvent(string eventId)
        {
            await _eventsDao.deleteEvent(eventId);
        }

        public async Task<List<Event>> getEvents()
        {
            var events = await _eventsDao.getEvents();
            return events;
        }

        public async Task<Event> postEvent(Event eventObj)
        {
            Logger.Info($"EventsService - Trying to create event with the name {eventObj.Title}.");
            var Event = await _eventsDao.postEvent(eventObj);
            return Event;
        }

        public async Task<Event> updateEvent(string eventId, Event eventObj)
        {
            var updatedEvent = await _eventsDao.updateEvent(eventId, eventObj);
            return updatedEvent;
        }
    }
}
