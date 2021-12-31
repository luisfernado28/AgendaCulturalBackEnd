using Events.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.DAO
{
    public class AuthenticationDAO: IAuthenticationDAO
    {
        private readonly IMongoCollection<User> _users;

        public AuthenticationDAO(IAgendaCulturalDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public async Task<List<User>> getUsers()
        {
            try
            {
                var filter = FilterDefinition<User>.Empty;
                var list = _users.FindAsync(filter).Result.ToList();
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User> getUserById(string userId)
        {
            try
            {
                var existingEvent = await _users.Find(eventFind => eventFind.Id == userId).FirstOrDefaultAsync();
                EventHandler(existingEvent != null);
                return existingEvent;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User> postUser(User user)
        {
            try
            {
                await _users.InsertOneAsync(user);
                return user;
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
    }
}
