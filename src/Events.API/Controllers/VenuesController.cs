using Events.Domain;
using Events.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("v1.0/venues")]
    public class VenuesController : ControllerBase
    {
        public IVenuesService _venuesService;
        public VenuesController(IVenuesService venuesService)
        {
            this._venuesService = venuesService;
        }

        // GET: VenuesController
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var venues = await _venuesService.getVenues();
            return Ok(venues);
        }

        //Get: VenuesController/Edit/5
        [HttpGet("{venueId}")]
        public async Task<ActionResult> EditAsync(string venueId)
        {
            try
            {
                var venue = await _venuesService.getVenueById(venueId);
                return Ok(venue);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Venue venue)
        {
            var Event = await _venuesService.postVenue(venue);
            return Ok(Event);
        }
    }
}
