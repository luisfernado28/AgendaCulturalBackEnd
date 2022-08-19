/*
 * Project: Agenda Cultural Back End Net Core
 * Author: Luis Fernando Choque (luisfernandochoquea@gmail.com)
 * -----
 * Copyright 2021 - 2022 Universidad Privada Boliviana La Paz, Luis Fernando Choque Arana
 */
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
