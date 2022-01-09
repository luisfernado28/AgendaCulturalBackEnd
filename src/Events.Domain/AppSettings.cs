using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain
{
    public class AppSettings: IAppSettings
    {
        public string JwtTokenKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }

    }

    public interface IAppSettings
    {
        string JwtTokenKey { get; set; }
        string Audience { get; set; }
        string Issuer { get; set; }
    }
}
