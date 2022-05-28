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
using System.Threading;
using System.Threading.Tasks;

namespace Events.API.Controllers
{
  [ApiController]
  [Route("v1.0/Events")]
  //[ODataRouteComponent("v1.0/Events")]
  //[ODataAttributeRouting]
  public class EventsController : ODataController
    {

        public IEventsService _fullEventsService;
        private static IList<Event> _events = new List<Event>
        {
            new Event
            {
                Id= "1",

                Title = "Coach",
                Artist = "coach",
                Description = "asdfadgege",
                Type = "2",
             
                //LocationCoordinates= "",
                //Dates= "",
                //Tags= "",
                //Time= "",

            },
            new Event
            {
                Id= "2",
                Title = "lolla",
                Artist = "lolla",
                Description = "afg lolla",
                Type = "2",
                 Address = "",
                Website= "",
                Status= eventStatus.active,
                AreIndependent= true,
                Facebook= "",
                ImageUrl= "",
                Instagram= "",
                LocationType= "",
                Phone= "",
                Price= 89,
                Twitter= "",
                VenueDescription= "",
                VenueFacebook= "",VenueId= "",
                VenueInstagram= "",
                VenueName= "",VenueTwitter= "",VenueWebsite= "",
            },
            new Event
            {
                Id= "3",
                Title = "rockinrio",
                Artist = "rockinrio",
                Description = "rockinrio asdfasg",
                Type = "2",
                 Address = "",
                Website= "",
                Status= eventStatus.active,
                AreIndependent= true,
                Facebook= "",
                ImageUrl= "",
                Instagram= "",
                LocationType= "",
                Phone= "",
                Price= 89,
                Twitter= "",
                VenueDescription= "",
                VenueFacebook= "",VenueId= "",
                VenueInstagram= "",
                VenueName= "",VenueTwitter= "",VenueWebsite= "",
            },
        };
        public EventsController(IEventsService fullEventsService)
        {
            this._fullEventsService = fullEventsService;
        }

        [HttpGet]
        [EnableQuery]
        //public IActionResult Get(CancellationToken token)

        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            var events =  await _fullEventsService.getFullEvents();
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
        [EnableQuery]
        [HttpPost]
        public IActionResult Post([FromBody] Event eventObj, CancellationToken token)
        {
            var createdEvent = _fullEventsService.postFullEvent(eventObj);
            return Created(createdEvent);
        }

        [HttpPut("{key}")]
        public ActionResult Put(string key, [FromBody] Event eventObj)
        {
            try
            {
                var updated=_fullEventsService.updateFullEvent(key, eventObj);
                return Updated(updated);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(string key)
        {
      try
      {
        _fullEventsService.deleteFullEvent(key);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

      return Ok();
        }
    }
}
