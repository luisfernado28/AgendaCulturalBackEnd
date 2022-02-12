using Events.Service;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
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
    }
}
