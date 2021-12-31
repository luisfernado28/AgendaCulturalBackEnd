using Events.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.DAO
{
    public interface IAuthenticationDAO
    {
        public Task<User> postUser(User user);
    }
}
