using Events.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.Service
{
    public interface IAuthenticationService
    {
        public List<User> getUsers();
        public User getUserById(string userId);
        public User postUser(User userObj);
        public Task<User> patchUser(string userId, User userObj);
        public Task deleteUser(string userId);
        public UserCredentailResponse Authenticate(UserCredential userCred);
        public void Logoff(UserCredentailResponse userCred);

    }
}
