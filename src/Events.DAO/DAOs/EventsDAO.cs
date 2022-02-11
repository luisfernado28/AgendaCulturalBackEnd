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

        public async Task<Event> patchEvent(string eventId, Event Event)
        {
            try
            {
                var existingEvent = await _events.Find(eventFind => eventFind.Id == eventId).FirstOrDefaultAsync();
                EventHandler(existingEvent != null);
                var patchedEvent=patchEvent(Event, existingEvent);
                await _events.ReplaceOneAsync(evnt => evnt.Id == eventId, patchedEvent);
                return patchedEvent;
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

        public Event patchEvent(Event patchedEvent, Event actualEvent)
        {
            return new Event
            {
                Id = patchedEvent.Id,
                Title = patchedEvent.Title ?? actualEvent.Title,
                Artist = patchedEvent.Artist ?? actualEvent.Artist,
                VenueId = patchedEvent.VenueId ?? actualEvent.VenueId,
                status = patchedEvent.status,
                Price = patchedEvent.Price ,
                Phone = patchedEvent.Phone ?? actualEvent.Phone,
                Type = patchedEvent.Type ?? actualEvent.Type,
                Description = patchedEvent.Description ?? actualEvent.Description,
                ImageUrl = patchedEvent.ImageUrl ?? actualEvent.ImageUrl,
                Dates = patchedEvent.Dates ?? actualEvent.Dates,
                Tags = patchedEvent.Tags ?? actualEvent.Tags,
                Website = patchedEvent.Website ?? actualEvent.Website,
                Facebook = patchedEvent.Facebook ?? actualEvent.Facebook,
                Twitter = patchedEvent.Twitter ?? actualEvent.Twitter,
                Instagram = patchedEvent.Instagram ?? actualEvent.Instagram,
            };
        }

        public async Task<Event> getEventsById(string eventId)
        {
            try
            {
                var existingEvent = await _events.Find(eventFind => eventFind.Id == eventId).FirstOrDefaultAsync();
                EventHandler(existingEvent != null);
                return existingEvent;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
