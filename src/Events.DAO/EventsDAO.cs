using Events.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.DAO
{
    public class EventsDAO : IEventsDAO
    {
        private readonly IMongoCollection<Event> _events;

        public EventsDAO(IAgendaCulturalDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _events = database.GetCollection<Event>(settings.EventsCollectionName);
        }

        public async Task<List<Event>> getEvents()
        {
            //List<Event> list = new List<Event>();
            //list.Add(new Event() { Id = "a", Title = "a wonderfull event" });
            //list.Add(new Event() { Id = "F", Title = "an awful event" });
            //return _events.Find(book => true).ToList(); 
            //List<Product> prods = new List<Product>();
            try
            {
                var filter = FilterDefinition<Event>.Empty;
                var list = _events.FindAsync(filter).Result.ToList();
                return list;
            }
                catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Event> postEvent(Event eventObj)
        {
            try
            {
                await _events.InsertOneAsync(eventObj);
                return eventObj;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
