using Events.DAO;
using Events.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Service
{
    public class EventsService : IEventsService
    {
        private IEventsDAO _eventsDao;
        private IVenuesDao _venuesDAO;


        public EventsService(IEventsDAO eventsDAO, IVenuesDao venuesDAO)
        {
            _eventsDao = eventsDAO;
            _venuesDAO = venuesDAO;

        }

        public async Task deleteEvent(string eventId)
        {
            await _eventsDao.deleteEvent(eventId);
        }

        public async Task<Event> getEventById(string eventId)
        {
           return await _eventsDao.getEventsById(eventId);
        }

        public async Task<List<Event>> getEvents()
        {
            var events = await _eventsDao.getEvents();
            return events;
        }

        public async Task<List<FullEvent>> getFullEvents()
        {
            var events = await _eventsDao.getEvents();
            var venuesIds = events.Select(eve=> eve.VenueId).Distinct().ToList();
            List<FullEvent> fullEvents = new List<FullEvent>();
            foreach(string id  in venuesIds)
            {
                if(id.Equals("No Venue"))
                {
                    var eventsOfVenue = from eventObj in events where eventObj.VenueId == id select eventObj;
                    eventsOfVenue = eventsOfVenue.ToList();
                    fullEvents = buildNoVenueFullEvent(fullEvents, (List<Event>)eventsOfVenue);
                }
                else
                {
                    var venue = await _venuesDAO.getVenuesById(id);
                    var eventsOfVenue = from eventObj in events where eventObj.VenueId == id select eventObj;
                    eventsOfVenue = eventsOfVenue.ToList();
                    fullEvents = buildFullEvents(fullEvents, (List<Event>)eventsOfVenue, venue);
                }
                
            }
            return fullEvents;
        }

        public Task<Event> patchEvent(string eventId, Event eventObj)
        {
            throw new System.NotImplementedException();
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

        private List<FullEvent> buildFullEvents(List<FullEvent> listOfCurrentFullEvents, List<Event>  events, Venue venue)
        {
            foreach(Event ev in events)
            {
                var newFullEvent = new FullEvent()
                {
                    Id = ev.Id,
                    Title = ev.Title,
                    Artist = ev.Artist,
                    Status= ev.status,
                    Price= ev.Price,
                    Phone= ev.Phone,
                    Type= ev.Type,
                    Description= ev.Description,
                    ImageUrl= ev.ImageUrl,
                    AreIndependent= ev.Dates.areindependent,
                    Dates= ev.Dates.dates,
                    Time= ev.Dates.time,
                    Tags= ev.Tags,
                    Facebook = ev.Facebook,
                    Twitter = ev.Twitter,
                    Instagram = ev.Instagram,
                    VenueId = ev.VenueId,
                    VenueName = venue.Name,
                    Address = venue.Address,
                    VenueWebsite = venue.Website,
                    VenueTwitter = venue.Twitter,
                    VenueInstagram = venue.Instagram,
                    VenueDescription = venue.Description,
                    LocationType = venue.Location.type,
                    LocationCoordinates= venue.Location.coordinates
                };
                listOfCurrentFullEvents.Add(newFullEvent);
            }
            
            return listOfCurrentFullEvents;
        }

        private List<FullEvent> buildNoVenueFullEvent(List<FullEvent> listOfCurrentFullEvents, List<Event> events)
        {
            foreach (Event ev in events)
            {
                var newFullEvent = new FullEvent()
                {
                    Id = ev.Id,
                    Title = ev.Title,
                    Artist = ev.Artist,
                    Status= ev.status,
                    Price = ev.Price,
                    Phone = ev.Phone,
                    Type = ev.Type,
                    Description = ev.Description,
                    ImageUrl = ev.ImageUrl,
                    AreIndependent= ev.Dates.areindependent,
                    Dates= ev.Dates.dates,
                    Time= ev.Dates.time,
                    Tags = ev.Tags,
                    Facebook = ev.Facebook,
                    Twitter = ev.Twitter,
                    Instagram = ev.Instagram,
                    VenueId = ev.VenueId,
                    VenueName = "",
                    Address = "",
                    VenueWebsite = "",
                    VenueTwitter = "",
                    VenueInstagram = "",
                    VenueDescription = "",
                    LocationType = "",
                    LocationCoordinates = new double[] {0,0}
                };
                listOfCurrentFullEvents.Add(newFullEvent);
            }

            return listOfCurrentFullEvents;
        }
    }
}
