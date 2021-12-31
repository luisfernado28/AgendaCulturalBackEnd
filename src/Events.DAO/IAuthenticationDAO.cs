using Events.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.DAO
{
    public interface IAuthenticationDAO
    {
        public Task<User> postUser(User user);
        public Task<List<User>> getUsers();
        public Task<User> getUserById(string userId);
    }
}
