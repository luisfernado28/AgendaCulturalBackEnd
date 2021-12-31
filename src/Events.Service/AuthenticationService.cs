using Events.DAO;
using Events.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;


namespace Events.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private IAuthenticationDAO  _authDao;

        public AuthenticationService(IAuthenticationDAO authDAO)
        {
            _authDao = authDAO;

        }

        public async Task deleteUser(string userId)
        {
            await _authDao.deleteUser(userId);
        }

        public async Task<User> getUserById(string userId)
        {
            return await _authDao.getUserById(userId);
        }

        public async Task<List<User>> getUsers()
        {
            var users= await _authDao.getUsers();
            return users;
        }

        public async Task<User> patchUser(string userId, User userObj)
        {
            try
            {
                var updated = await _authDao.patchUser(userId, userObj);
                var account = await _authDao.getUserById(userId);
                return account;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User> postUser(User userObj)
        {
            Logger.Info($"EventsService - Trying to create user with the name of {userObj.Username}.");
            userObj.Password = BC.HashPassword(userObj.Password);

            var User = await _authDao.postUser(userObj);
            return User;
        }
    }
}
