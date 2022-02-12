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


        public async Task deleteFullEvent(string fullEventId)
        {
            try
            {
                var existingEvent = await _fullEvents.Find(eventFind => eventFind.Id == fullEventId).FirstOrDefaultAsync();
                if (existingEvent == null)
                    throw new KeyNotFoundException();
                DeleteResult deleteResult = await _fullEvents.DeleteOneAsync(evnt => evnt.Id == fullEventId);
                EventHandler(deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

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

        public async Task<FullEvent> updateFullEvent(string eventId, FullEvent fullEvent)
        {
            try
            {
                var existingEvent = await _fullEvents.Find(fullEvent => fullEvent.Id == eventId).FirstOrDefaultAsync();
                EventHandler(existingEvent != null);
                fullEvent.Id = eventId;
                await _fullEvents.ReplaceOneAsync(evnt => evnt.Id == eventId, fullEvent);
                return fullEvent;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<FullEvent> patchFullEvent(string eventId, FullEvent fullEvent)
        {
            try
            {
                var existingEvent = await _fullEvents.Find(eventFind => eventFind.Id == eventId).FirstOrDefaultAsync();
                EventHandler(existingEvent != null);
                var patchedEvent = patchFullEvent(fullEvent, existingEvent);
                await _fullEvents.ReplaceOneAsync(evnt => evnt.Id == eventId, patchedEvent);
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

        public FullEvent patchFullEvent(FullEvent patchedEvent, FullEvent actualEvent)
        {
            return new FullEvent
            {
                Id = patchedEvent.Id,
                Title = patchedEvent.Title ?? actualEvent.Title,
                Artist = patchedEvent.Artist ?? actualEvent.Artist,
                Status= patchedEvent.Status,
                Price = patchedEvent.Price ,
                Phone = patchedEvent.Phone ?? actualEvent.Phone,
                Type = patchedEvent.Type ?? actualEvent.Type,
                Description = patchedEvent.Description ?? actualEvent.Description,
                ImageUrl = patchedEvent.ImageUrl ?? actualEvent.ImageUrl,
                AreIndependent= patchedEvent.AreIndependent,
                Dates = patchedEvent.Dates ?? actualEvent.Dates,
                Time = patchedEvent.Time,
                Tags = patchedEvent.Tags ?? actualEvent.Tags,
                Website = patchedEvent.Website ?? actualEvent.Website,
                Facebook = patchedEvent.Facebook ?? actualEvent.Facebook,
                Twitter = patchedEvent.Twitter ?? actualEvent.Twitter,
                Instagram = patchedEvent.Instagram ?? actualEvent.Instagram,
                VenueId = patchedEvent.VenueId ?? actualEvent.VenueId,
                VenueName = patchedEvent.VenueName ?? actualEvent.VenueName,
                Address= patchedEvent.Address ?? actualEvent.Address,
                VenueDescription = patchedEvent.VenueDescription ?? actualEvent.VenueDescription,
                VenueFacebook = patchedEvent.VenueFacebook ?? actualEvent.VenueFacebook,
                VenueInstagram= patchedEvent.VenueInstagram ?? actualEvent.VenueInstagram,
                VenueTwitter = patchedEvent.VenueTwitter ?? actualEvent.VenueTwitter,
                VenueWebsite= patchedEvent.VenueWebsite ?? actualEvent.VenueWebsite,
                LocationType= patchedEvent.LocationType ?? actualEvent.LocationType,
                LocationCoordinates = patchedEvent.LocationCoordinates ?? actualEvent.LocationCoordinates
            };
        }

    }
}
