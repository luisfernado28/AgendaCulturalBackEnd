﻿namespace Events.Domain
{
    public class AgendaCulturalDatabaseSettings : IAgendaCulturalDatabaseSettings
    {
        public string EventsCollectionName { get; set; }
        public string VenuesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IAgendaCulturalDatabaseSettings
    {
        string EventsCollectionName { get; set; }
        string VenuesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

}
