/*
 * Project: Agenda Cultural Back End Net Core
 * Author: Luis Fernando Choque (luisfernandochoquea@gmail.com)
 * -----
 * Copyright 2021 - 2022 Universidad Privada Boliviana La Paz, Luis Fernando Choque Arana
 */
using Events.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.DAO
{
    public interface IEventsDAO
    {
        public Task<List<Event>> getFullEvents();
        public Event getFullEventsById(string fullEventId);
        public Event postFullEvent(Event fullEvent);
        public Event updateFullEvent(string eventId, Event fullEvent);
        public Event patchFullEvent(string eventId, Event fullEvent);
        public void deleteFullEvent(string fullEventId);
    }
}
