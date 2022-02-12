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
        public Task<FullEvent> postFullEvent(FullEvent fullEvent);
        public Task<FullEvent> updateFullEvent(string eventId, FullEvent fullEvent);
        public Task<FullEvent> patchFullEvent(string eventId, FullEvent fullEvent);
        public Task deleteFullEvent(string fullEventId);
    }
}
