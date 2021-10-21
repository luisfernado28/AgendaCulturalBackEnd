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

        // GET: VenueController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //POST: VenuesController/Edit/5
        [HttpPut("{venueId}")]
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

        // GET: VenueController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: VenueController/Create
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

        // GET: VenueController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: VenueController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: VenueController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: VenueController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
