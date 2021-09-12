using Events.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Service
{
    public interface IEventsService
    {
        public Task<List<Event>> getEvents();
    }
}
