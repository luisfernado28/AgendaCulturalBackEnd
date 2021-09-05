using Events.Domain;
using System;
using System.Collections.Generic;

namespace Events.DAO
{
    public class EventsDAO
    {
        public EventsDAO()
        {
        }
        public List<Event> getEvents()
        {
            List<Event> list = new List<Event>();
            list.Add(new Event() { Id="a",Title="a wonderfull event"});
            return list;
        }
    }
}
