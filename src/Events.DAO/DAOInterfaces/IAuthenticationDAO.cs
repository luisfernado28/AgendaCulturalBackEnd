using Events.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.DAO
{
    public interface IAuthenticationDAO
    {
        public User postUser(User user);
        public List<User> getUsers();
        public User getUserById(string userId);
        public User getUsersByUserName(string userName);
        public Task<User> patchUser(string userId, User user);
        public Task deleteUser(string userId);
    }
}
