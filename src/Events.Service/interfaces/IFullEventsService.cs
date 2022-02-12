using Events.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.Service
{
    public interface IFullEventsService
    {
        public Task<List<FullEvent>> getFullEvents();
        public Task<FullEvent> getFullEventById(string fullEventId);
        public Task<FullEvent> postFullEvent(FullEvent fullEventObj);
        public Task<FullEvent> updateFullEvent(string fullEventId, FullEvent fullEvent);
        public Task<FullEvent> patchFullEvent(string fullEventId, FullEvent fullEvent);
        public Task deleteFullEvent(string fullEvent);
    }
}
