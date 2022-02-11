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

        public Task<FullEvent> getFullEventById(string fullEventId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<FullEvent>> getFullEvents()
        {
            var fullEvents = await _fullEventsDao.getFullEvents();
            return fullEvents;
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
                    AreIndependent = ev.Dates.areindependent,
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
                    AreIndependent = ev.Dates.areindependent,
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
