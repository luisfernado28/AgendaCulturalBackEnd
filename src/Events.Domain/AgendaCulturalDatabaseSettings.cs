/*
 * Project: Agenda Cultural Back End Net Core
 * Author: Luis Fernando Choque (luisfernandochoquea@gmail.com)
 * -----
 * Copyright 2021 - 2022 Universidad Privada Boliviana La Paz, Luis Fernando Choque Arana
 */
namespace Events.Domain
{
    public class AgendaCulturalDatabaseSettings : IAgendaCulturalDatabaseSettings
    {
        public string EventsCollectionName { get; set; }
        public string FullEventsCollectionName { get; set; }
        public string VenuesCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IAgendaCulturalDatabaseSettings
    {
        string EventsCollectionName { get; set; }
        string FullEventsCollectionName { get; set; }
        string VenuesCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

}
