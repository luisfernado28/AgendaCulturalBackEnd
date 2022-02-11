using Events.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.DAO
{
    public interface IVenuesDao
    {
        public Task<List<Venue>> getVenues();
        public Task<Venue> getVenuesById(string venueId);
        public Task<Venue> postVenue(Venue venue);
        public Task<Venue> updateVenue(string eventId, Venue venue);
        public Task deleteVenue(string eventId);
    }
}
