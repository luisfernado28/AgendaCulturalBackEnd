using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain
{
        public class AgendaCulturalDatabaseSettings : IAgendaCulturalDatabaseSettings
        {
            public string EventsCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }

        public interface IAgendaCulturalDatabaseSettings
        {
            string EventsCollectionName { get; set; }
            string ConnectionString { get; set; }
            string DatabaseName { get; set; }
        }
    
}
