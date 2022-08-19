/*
 * Project: Agenda Cultural Back End Net Core
 * Author: Luis Fernando Choque (luisfernandochoquea@gmail.com)
 * -----
 * Copyright 2021 - 2022 Universidad Privada Boliviana La Paz, Luis Fernando Choque Arana
 */
using Events.DAO;
using Events.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Service
{
    public class EventsService : IEventsService
    {
        private IEventsDAO _fullEventsDao;
        

        public EventsService(IEventsDAO fullEventsDAO)
        {
            _fullEventsDao = fullEventsDAO;
        }

        public void deleteFullEvent(string fullEvent)
        {
            _fullEventsDao.deleteFullEvent(fullEvent);
        }

        public Event getFullEventById(string fullEventId)
        {

            return  _fullEventsDao.getFullEventsById(fullEventId);
        }

        public async Task<List<Event>> getFullEvents()
        {
            var fullEvents = await _fullEventsDao.getFullEvents();
            return fullEvents;
        }

        public Event patchFullEvent(string fullEventId, Event fullEvent)
        {
            throw new System.NotImplementedException();
        }

        public Event postFullEvent(Event fullEventObj)
        {
            Logger.Info($"EventsService - Trying to create full event with the name {fullEventObj.Title}.");
            var Event = _fullEventsDao.postFullEvent(fullEventObj);
            return Event;
        }

        public Event updateFullEvent(string fullEventId, Event fullEvent)
        {
            var updatedEvent = _fullEventsDao.updateFullEvent(fullEventId, fullEvent);
            return updatedEvent;
        }

      
    }
}
