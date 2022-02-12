using Events.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.DAO
{
    public class FullEventsDAO : IFullEventsDAO
    {
        private readonly IMongoCollection<FullEvent> _fullEvents;

        public FullEventsDAO(IAgendaCulturalDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _fullEvents = database.GetCollection<FullEvent>(settings.FullEventsCollectionName);
        }

        public async Task<List<FullEvent>> getFullEvents()
        {
            try
            {
                var filter = FilterDefinition<FullEvent>.Empty;
                var list = _fullEvents.FindAsync(filter).Result.ToList();
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<FullEvent> getFullEventsById(string fullEventId)
        {
            try
            {
                var existingEvent = await _fullEvents.Find(eventFind => eventFind.Id == fullEventId).FirstOrDefaultAsync();
                EventHandler(existingEvent != null);
                return existingEvent;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //public async Task deleteEvent(string eventId)
        //{
        //    try
        //    {
        //        var existingEvent = await _fullEvents.Find(eventFind => eventFind.Id == eventId).FirstOrDefaultAsync();
        //        if (existingEvent == null)
        //            throw new KeyNotFoundException();
        //        DeleteResult deleteResult = await _fullEvents.DeleteOneAsync(evnt => evnt.Id == eventId);
        //        EventHandler(deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        public async Task<FullEvent> postFullEvent(FullEvent fullEvent)
        {
            try
            {
                fullEvent.Status= eventStatus.active;
                await _fullEvents.InsertOneAsync(fullEvent);
                return fullEvent;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<FullEvent> updateFullEvent(string eventId, FullEvent fullEvent)
        {
            throw new NotImplementedException();
        }

        public Task<FullEvent> patchFullEvent(string eventId, FullEvent fullEvent)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<Event>> getEvents()
        //{
        //    try
        //    {
        //        var filter = FilterDefinition<Event>.Empty;
        //        var list =  _fullEvents.FindAsync(filter).Result.ToList();
        //        return list;
        //    }
        //        catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<Event> postEvent(Event eventObj)
        //{
        //    try
        //    {
        //        eventObj.status = eventStatus.active;
        //        await _fullEvents.InsertOneAsync(eventObj);
        //        return eventObj;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<Event> updateEvent(string eventId, Event eventObj)
        //{
        //    try
        //    {
        //        var existingEvent = await _fullEvents.Find(eventFind => eventFind.Id == eventId).FirstOrDefaultAsync();
        //        EventHandler(existingEvent != null);
        //        eventObj.Id = eventId;
        //        await _fullEvents.ReplaceOneAsync(evnt => evnt.Id == eventId, eventObj);
        //        return eventObj;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<Event> patchEvent(string eventId, Event Event)
        //{
        //    try
        //    {
        //        var existingEvent = await _fullEvents.Find(eventFind => eventFind.Id == eventId).FirstOrDefaultAsync();
        //        EventHandler(existingEvent != null);
        //        var patchedEvent=patchEvent(Event, existingEvent);
        //        await _fullEvents.ReplaceOneAsync(evnt => evnt.Id == eventId, patchedEvent);
        //        return patchedEvent;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }

        //}

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

        public Task deleteFullEvent(string fullEventId)
        {
            throw new NotImplementedException();
        }
    }
}
