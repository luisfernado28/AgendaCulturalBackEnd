using Events.Domain;
using Events.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("v1.0/auth")]
    public class UsersController : ODataController
    {
        public IAuthenticationService _authService;
        public UsersController(IAuthenticationService authService)
        {
            this._authService = authService;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get(CancellationToken token)
        {
            var events = _authService.getUsers();
            return Ok(events);
        }

        [EnableQuery]
        [HttpGet("{key}")]
        public IActionResult Get(string key)
        {
            try
            {
                var user = _authService.getUserById(key);
                return Ok(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] User userObj)
        {
            var User =  _authService.postUser(userObj);
            return Ok(User);
        }

        [HttpPatch("{userId}")]
        public async Task<ActionResult> PatchAsync(string userId, [FromBody] User userObj)
        {
            try
            {
                var patchedUser = await _authService.patchUser(userId, userObj);
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

        [HttpPost("token")]
        public IActionResult Auth([FromBody] UserCredential userCredentials)
        {
            return Ok(_authService.Authenticate(userCredentials));
        }

        [HttpPost("logoff")]
        public IActionResult Logoff([FromBody] UserCredentailResponse userCredentials)
        {
            _authService.Logoff(userCredentials);
            return Ok();
        }
    }
}
