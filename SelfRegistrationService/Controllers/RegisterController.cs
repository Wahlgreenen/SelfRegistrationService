using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SelfRegistrationService
{
    [Route("api/")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private List<string> serverAdresses = new();

        [HttpPost("Register")]
        public IActionResult RegisterServer([FromBody] string address)
        {
            Console.WriteLine("incoming address: " + address);
            serverAdresses.Add(address);
            return Ok("Server registered successfully.");
        }

        [HttpGet("GetServers"), Authorize]
        public IActionResult GetServers()
        {
            if (serverAdresses.Count == 0)
                return NotFound("No active gameservers.");

            return Ok(serverAdresses);
        }
    }
}