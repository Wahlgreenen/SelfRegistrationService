using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SelfRegistrationService
{
    [Route("api/")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private static List<string> serverAdresses = new();

        [HttpPost("Register")]
        public IActionResult RegisterServer([FromBody] RegisterRequest request)
        {
            if (string.IsNullOrEmpty(request.Address))
                return BadRequest("Address is required.");

            Console.WriteLine("incoming address: " + request.Address);
            serverAdresses.Add(request.Address);
            return Ok("Server registered successfully. " + request.Address);
        }

        [HttpGet("GetServers"), Authorize]
        public IActionResult GetServers()
        {
            if (serverAdresses.Count == 0)
                return NoContent();

            return Ok(serverAdresses);
        }
    }

    public class RegisterRequest
    {
        public string Address { get; set; }
    }
}