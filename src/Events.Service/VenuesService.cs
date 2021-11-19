using Events.DAO;
using Events.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Service
{
    public class VenuesService : IVenuesService
    {
        private IVenuesDao _venuesDAO;
        public VenuesService(IVenuesDao venuesDAO)
        {
            _venuesDAO = venuesDAO;
        }
        public Task deleteVenue(string VenueId)
        {
            throw new NotImplementedException();
        }

        public async Task<Venue> getVenueById(string venueId)
        {
            var venue = await _venuesDAO.getVenuesById(venueId);
            return venue;
        }

        public async Task<List<Venue>> getVenues()
        {
            var events = await _venuesDAO.getVenues();
            return events;
        }

        public async Task<Venue> postVenue(Venue venueObj)
        {
            Logger.Info($"EventsService - Trying to create venue with the name {venueObj.Name}");
            var venue = await _venuesDAO.postVenue(venueObj);
            return venue;
        }

        public Task<Venue> updateVenue(string venueId, Venue venueObj)
        {
            throw new NotImplementedException();
        }
    }
}
