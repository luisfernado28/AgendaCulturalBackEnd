using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private IAuthenticationService  _authDao;

        public AuthenticationService(IAuthenticationService authDAO)
        {
            _authDao = authDAO;

        }
    }
}
