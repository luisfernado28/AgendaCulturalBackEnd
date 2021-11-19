using Events.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Service
{
    public interface IVenuesService
    {
        public Task<List<Venue>> getVenues();
        public Task<Venue> postVenue(Venue venueObj);
        public Task<Venue> getVenueById(string venueId);
        public Task<Venue> updateVenue(string venueId, Venue venueObj);
        public Task deleteVenue(string VenueId);
    }
}
