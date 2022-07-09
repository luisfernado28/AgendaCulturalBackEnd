using Events.Domain;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.API.Jobs
{
  [DisallowConcurrentExecution]
  public class DeactivateEventsJob : IJob
  {
    private readonly ILogger<DeactivateEventsJob> _logger;
    private readonly IMongoCollection<Event> _fullEvents;

    public DeactivateEventsJob(ILogger<DeactivateEventsJob> logger, IAgendaCulturalDatabaseSettings settings)
    {
      _logger = logger;
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);
      _fullEvents = database.GetCollection<Event>(settings.FullEventsCollectionName);
    }

    public Task Execute(IJobExecutionContext context)
    {
      _logger.LogInformation("Deactivating Events !");
      try
      {
        List<Event> listOfActiveEvents = _fullEvents.FindAsync(eventFind => eventFind.Status == "active").Result.ToList();

        foreach (Event activeEvent in listOfActiveEvents)
        {
          List<DateTime> datesArray = activeEvent.Dates;
          DateTime maxDate = datesArray.Max(record => record.Date);
          if (maxDate < DateTime.Now)
          {
            activeEvent.Status = "inactive";
            _fullEvents.ReplaceOne(eventFind => eventFind.Id == activeEvent.Id, activeEvent);

          }
        }
        List<Event> listOfInactiveEvents = _fullEvents.FindAsync(eventFind => eventFind.Status == "inactive").Result.ToList();

        foreach (Event inactiveEvent in listOfInactiveEvents)
        {
          List<DateTime> datesArray = inactiveEvent.Dates;
          DateTime minDate = datesArray.Min(record => record.Date);
          if (minDate > DateTime.Now)
          {
            inactiveEvent.Status = "active";
            _fullEvents.ReplaceOne(eventFind => eventFind.Id == inactiveEvent.Id, inactiveEvent);

          }
        }

      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
      return Task.CompletedTask;
    }
  }
}
