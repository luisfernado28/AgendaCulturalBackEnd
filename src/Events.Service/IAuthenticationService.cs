using Events.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.Service
{
    public interface IAuthenticationService
    {
        public Task<User> postUser(User userObj);
        public Task<List<User>> getUsers();
        public Task<User> getEventById(string userId);

    }
}
