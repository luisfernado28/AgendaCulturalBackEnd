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

        public Task<Venue> getVenueById(string venueId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Venue>> getVenues()
        {
            var events = await _venuesDAO.getVenues();
            return events;
        }

        public Task<Venue> postVenues(Venue venueObj)
        {
            throw new NotImplementedException();
        }

        public Task<Venue> updateVenue(string venueId, Venue venueObj)
        {
            throw new NotImplementedException();
        }
    }
}
