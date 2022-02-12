using Events.DAO;
using Events.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Service
{
    public class FullEventsService : IFullEventsService
    {
        private IFullEventsDAO _fullEventsDao;
        

        public FullEventsService(IFullEventsDAO fullEventsDAO)
        {
            _fullEventsDao = fullEventsDAO;
        }

        public async Task deleteFullEvent(string fullEvent)
        {
            await _fullEventsDao.deleteFullEvent(fullEvent);
        }

        public async Task<FullEvent> getFullEventById(string fullEventId)
        {

            return await _fullEventsDao.getFullEventsById(fullEventId);
        }

        public async Task<List<FullEvent>> getFullEvents()
        {
            var fullEvents = await _fullEventsDao.getFullEvents();
            return fullEvents;
        }

        public Task<FullEvent> patchFullEvent(string fullEventId, FullEvent fullEvent)
        {
            throw new System.NotImplementedException();
        }

        public async Task<FullEvent> postFullEvent(FullEvent fullEventObj)
        {
            Logger.Info($"EventsService - Trying to create full event with the name {fullEventObj.Title}.");
            var Event = await _fullEventsDao.postFullEvent(fullEventObj);
            return Event;
        }

        public async Task<FullEvent> updateFullEvent(string fullEventId, FullEvent fullEvent)
        {
            var updatedEvent = await _fullEventsDao.updateFullEvent(fullEventId, fullEvent);
            return updatedEvent;
        }

      
    }
}
