using Events.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.DAO
{
    public class EventsDAO : IEventsDAO
    {
        private readonly IMongoCollection<Event> _events;

        public EventsDAO(IAgendaCulturalDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _events = database.GetCollection<Event>(settings.EventsCollectionName);
        }

        public async Task deleteEvent(string eventId)
        {
            try
            {
                var existingEvent = await _events.Find(eventFind => eventFind.Id == eventId).FirstOrDefaultAsync();
                if (existingEvent == null)
                    throw new KeyNotFoundException();
                DeleteResult deleteResult = await _events.DeleteOneAsync(evnt => evnt.Id == eventId);
                EventHandler(deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Event>> getEvents()
        {
            try
            {
                var filter = FilterDefinition<Event>.Empty;
                var list =  _events.FindAsync(filter).Result.ToList();
                return list;
            }
                catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Event> postEvent(Event eventObj)
        {
            try
            {
                eventObj.status = eventStatus.active;
                await _events.InsertOneAsync(eventObj);
                return eventObj;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Event> updateEvent(string eventId, Event eventObj)
        {
            try
            {
                var existingEvent = await _events.Find(eventFind => eventFind.Id == eventId).FirstOrDefaultAsync();
                EventHandler(existingEvent != null);
                eventObj.Id = eventId;
                await _events.ReplaceOneAsync(evnt => evnt.Id == eventId, eventObj);
                return eventObj;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void EventHandler(bool flag)
        {
            if (!flag) { throw new KeyNotFoundException(); }
        }
    }
}
