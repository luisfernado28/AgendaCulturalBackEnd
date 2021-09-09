using Events.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.API
{
    public class ServicesFacade
    {
        public EventsService Events { get; }
        private ServicesFacade()
        {
            this.Events = new EventsService();
        }

        private static ServicesFacade _instance;
        public static ServicesFacade Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServicesFacade();
                }
                return _instance;
            }
        }
    }
}
