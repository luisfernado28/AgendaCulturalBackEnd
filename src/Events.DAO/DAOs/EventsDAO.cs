/*
 * Project: Agenda Cultural Back End Net Core
 * Author: Luis Fernando Choque (luisfernandochoquea@gmail.com)
 * -----
 * Copyright 2021 - 2022 Universidad Privada Boliviana La Paz, Luis Fernando Choque Arana
 */
using Events.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.DAO
{
    public class EventsDAO : IEventsDAO
    {
        private readonly IMongoCollection<Event> _fullEvents;

        public EventsDAO(IAgendaCulturalDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _fullEvents = database.GetCollection<Event>(settings.FullEventsCollectionName);
        }

        public async Task<List<Event>> getFullEvents()
        {
            try
            {
                var filter = FilterDefinition<Event>.Empty;
                var list =  _fullEvents.FindAsync(filter).Result.ToList();
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Event getFullEventsById(string fullEventId)
        {
            try
            {
                var existingEvent = _fullEvents.Find(eventFind => eventFind.Id == fullEventId).FirstOrDefault();
                EventHandler(existingEvent != null);
                return existingEvent;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public void deleteFullEvent(string fullEventId)
        {
            try
            {
                var existingEvent =  _fullEvents.Find(eventFind => eventFind.Id == fullEventId).FirstOrDefault();
                if (existingEvent == null)
                    throw new KeyNotFoundException();
                DeleteResult deleteResult = _fullEvents.DeleteOne(evnt => evnt.Id == fullEventId);
                EventHandler(deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Event postFullEvent(Event fullEvent)
        {
            try
            {
                //fullEvent.Status= eventStatus.active;
                 _fullEvents.InsertOne(fullEvent);
                return fullEvent;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Event updateFullEvent(string eventId, Event fullEvent)
        {
            try
            {
                var existingEvent =  _fullEvents.Find(fullEvent => fullEvent.Id == eventId).FirstOrDefault();
                EventHandler(existingEvent != null);
                fullEvent.Id = eventId;
                _fullEvents.ReplaceOne(evnt => evnt.Id == eventId, fullEvent);
                return fullEvent;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Event patchFullEvent(string eventId, Event fullEvent)
        {
            try
            {
                var existingEvent = _fullEvents.Find(eventFind => eventFind.Id == eventId).FirstOrDefault();
                EventHandler(existingEvent != null);
                var patchedEvent = patchFullEvent(fullEvent, existingEvent);
                _fullEvents.ReplaceOne(evnt => evnt.Id == eventId, patchedEvent);
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

        public Event patchFullEvent(Event patchedEvent, Event actualEvent)
        {
            return new Event
            {
                Id = patchedEvent.Id,
                Title = patchedEvent.Title ?? actualEvent.Title,
                Artist = patchedEvent.Artist ?? actualEvent.Artist,
                //Status= patchedEvent.Status,
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
