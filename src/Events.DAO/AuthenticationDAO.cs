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
        public async Task<User> patchUser(string userId, User user)
        {
            try
            {
                var existingEvent = await _users.Find(eventFind => eventFind.Id == userId).FirstOrDefaultAsync();
                EventHandler(existingEvent != null);
                user.Id = userId;
                var patchedUser = userPatcher(user, existingEvent);
                await _users.ReplaceOneAsync(evnt => evnt.Id == userId, patchedUser);
                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task deleteUser(string userId)
        {
            try
            {
                var existingEvent = await _users.Find(eventFind => eventFind.Id == userId).FirstOrDefaultAsync();
                if (existingEvent == null)
                    throw new KeyNotFoundException();
                DeleteResult deleteResult = await _users.DeleteOneAsync(evnt => evnt.Id == userId);
                EventHandler(deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0);
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

        private User userPatcher(User updatedUser, User storedUser)
        {
            return new User
            {
                Id = storedUser.Id,
                Username = updatedUser.Username ?? storedUser.Username,
                Firstname = updatedUser.Firstname ?? storedUser.Firstname,
                Lastname = updatedUser.Lastname ?? storedUser.Lastname,
                Password = storedUser.Password,
                Admin = updatedUser.Admin,
            };
        }
    }
}
