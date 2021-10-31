using Events.Domain;
using Events.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("v1.0/events")]
    public class EventsController : ControllerBase
    {
        public IEventsService _eventsService;
        public EventsController(IEventsService eventsService)
        {
            this._eventsService = eventsService;
        }

        // GET: EventsController
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _eventsService.getEvents();
            return Ok(events);
        }

        // GET: EventsController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: EventsController/Create
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Event eventObj)
        {
            var Event = await _eventsService.postEvent(eventObj);
            return Ok(Event);
        }

        // POST: EventsController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: EventsController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //PUT: EventsController/eventId
        [HttpPut("{eventId}")]
        public async Task<ActionResult> EditAsync(string eventId, [FromBody] Event eventObj)
        {
            try
            {
                await _eventsService.updateEvent(eventId, eventObj);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Patch: EventsController/eventId
        [HttpPatch("{eventId}")]
        public async Task<ActionResult> PatchAsync(string eventId, [FromBody] Event eventObj)
        {
            try
            {
                await _eventsService.updateEvent(eventId, eventObj);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{eventId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(string eventId)
        {
            try
            {
                await _eventsService.deleteEvent(eventId);
                return NoContent();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
