/*
 * Project: Agenda Cultural Back End Net Core
 * Author: Luis Fernando Choque (luisfernandochoquea@gmail.com)
 * -----
 * Copyright 2021 - 2022 Universidad Privada Boliviana La Paz, Luis Fernando Choque Arana
 */
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
