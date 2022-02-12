using Events.Domain;
using Events.Service;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("v1.0/fullEvents")]
    public class FullEventController : ControllerBase
    {

        public IFullEventsService _fullEventsService;
        public FullEventController(IFullEventsService fullEventsService)
        {
            this._fullEventsService= fullEventsService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetFullEvent()
        {
            var events = await _fullEventsService.getFullEvents();
            return Ok(events);
        }

        [HttpGet("{fullEventId}")]
        public async Task<ActionResult> GetFullEventById(string fullEventId)
        {
            try
            {
                var x = await _fullEventsService.getFullEventById(fullEventId);
                return Ok(x);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] FullEvent eventObj)
        {
            var Event = await _fullEventsService.postFullEvent(eventObj);
            return Ok(Event);
        }

        [HttpDelete("{fullEventId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(string fullEventId)
        {
            try
            {
                await _fullEventsService.deleteFullEvent(fullEventId);
                return NoContent();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //PUT: EventsController/eventId
        [HttpPut("{eventId}")]
        public async Task<ActionResult> EditAsync(string eventId, [FromBody] FullEvent eventObj)
        {
            try
            {
                await _fullEventsService.updateFullEvent(eventId, eventObj);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
