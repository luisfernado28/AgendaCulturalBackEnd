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
    [Route("v1.0/auth")]
    public class AuthenticationController : ControllerBase
    {
        public IAuthenticationService _authService;
        public AuthenticationController(IAuthenticationService authService)
        {
            this._authService = authService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetUsers()
        {
            var events = await _authService.getUsers();
            return Ok(events);
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult> GetEventById(string eventId)
        {
            try
            {
                var user = await _authService.getUserById(eventId);
                return Ok(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] User userObj)
        {
            var User = await _authService.postUser(userObj);
            return Ok(User);
        }

        [HttpPatch("{userId}")]
        public async Task<ActionResult> PatchAsync(string userId, [FromBody] User userObj)
        {
            try
            {
                var patchedUser=await _authService.patchUser(userId, userObj);
                return Ok(patchedUser);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(string userId)
        {
            try
            {
                await _authService.deleteUser(userId);
                return NoContent();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
