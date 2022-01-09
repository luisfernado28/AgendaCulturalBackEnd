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
                var existinguser = await _users.Find(userFind => userFind.Id == userId).FirstOrDefaultAsync();
                EventHandler(existinguser != null);
                return existinguser;
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
                var existinguser = await _users.Find(userFind => userFind.Id == userId).FirstOrDefaultAsync();
                EventHandler(existinguser != null);
                user.Id = userId;
                var patchedUser = userPatcher(user, existinguser);
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
                var existinguser = await _users.Find(userFind => userFind.Id == userId).FirstOrDefaultAsync();
                if (existinguser == null)
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

        public User getUsersByUserName(string userName)
        {
            try
            {
                var existingUser = _users.Find(userFind => userFind.Username == userName).FirstOrDefaultAsync();
                //EventHandler(existingEvent != null);
                return existingUser.Result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
