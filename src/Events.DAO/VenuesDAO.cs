using Events.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.DAO
{
    public class VenuesDAO : IVenuesDao
    {
        private readonly IMongoCollection<Venue> _venueDAO;

        public VenuesDAO(IAgendaCulturalDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _venueDAO = database.GetCollection<Venue>(settings.VenuesCollectionName);
        }

        public Task deleteVenue(string eventId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Venue>> getVenues()
        {
            try
            {
                var filter = FilterDefinition<Venue>.Empty;
                var list = _venueDAO.FindAsync(filter).Result.ToList();
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Venue> getVenuesById(string venueId)
        {
            try
            {
                var venue = await _venueDAO.Find(venue => venue.Id == venueId).FirstOrDefaultAsync();
                EventHandler(venue != null);
                return venue;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Venue> postVenue(Venue venue)
        {
            try
            {
                await _venueDAO.InsertOneAsync(venue);
                return venue;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<Venue> updateVenue(string eventId, Venue venue)
        {
            throw new NotImplementedException();
        }

        public void EventHandler(bool flag)
        {
            if (!flag) { throw new KeyNotFoundException(); }
        }
    }
}
