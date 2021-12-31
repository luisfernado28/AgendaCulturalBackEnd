using Events.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.Service
{
    public interface IAuthenticationService
    {
        public Task<User> postUser(User userObj);
        public Task<List<User>> getUsers();
        public Task<User> getUserById(string userId);
        public Task<User> patchUser(string userId, User userObj);
        public Task deleteUser(string userId);
    }
}
