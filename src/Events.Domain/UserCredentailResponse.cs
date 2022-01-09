using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain
{
    public class UserCredentailResponse
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool Admin { get; set; }
        public string Token { get; set; }

    }
}
