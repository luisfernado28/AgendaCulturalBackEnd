using Events.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.DAO
{
    public class EventsDAO
    {
        public EventsDAO()
        {
        }
        public async Task<List<Event>> getEvents()
        {
            List<Event> list = new List<Event>();
            list.Add(new Event() { Id = "a",Title="a wonderfull event"});
            list.Add(new Event() { Id = "F", Title = "an awful event" });
            return list;
        }
    }
}
