using Events.Domain;
using MongoDB.Driver;
using System;
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
    }
}
