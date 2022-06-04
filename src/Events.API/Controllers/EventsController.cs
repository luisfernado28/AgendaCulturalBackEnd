using Events.Domain;
using Events.Service;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Events.API.Controllers
{
  [ApiController]
  [Route("v1.0/Events")]
  public class EventsController : ODataController
  {

    public IEventsService _fullEventsService;
    public EventsController(IEventsService fullEventsService)
    {
      this._fullEventsService = fullEventsService;
    }

    [HttpGet]
    [EnableQuery]
    //public IActionResult Get(CancellationToken token)

    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
      var events = await _fullEventsService.getFullEvents();
      return Ok(events);
    }

    [EnableQuery]
    [HttpGet("{key}")]
    public IActionResult Get(string key)

    {
      try
      {
        var x = _fullEventsService.getFullEventById(key);
        return Ok(x);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    //without from body it works fine sends the parameterson the url
    //[EnableQuery]
    [HttpPost]
    public ActionResult Create([FromBody] Event eventObj)
    {

      var createdEvent = _fullEventsService.postFullEvent(eventObj);
      //return Created(createdEvent);
      return Ok(createdEvent);
    }

    [HttpPut("{key}")]
    public ActionResult Put(string key, [FromBody] Event eventObj)
    {
      try
      {
        var updated = _fullEventsService.updateFullEvent(key, eventObj);
        return Updated(updated);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    [HttpDelete("{userId}")]
    public IActionResult Delete(string userId)
    {
      try
      {
        _fullEventsService.deleteFullEvent(userId);
        return NoContent();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

    }
  }
}
